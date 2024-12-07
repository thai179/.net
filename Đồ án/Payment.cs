using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmThanhToan : Form
    {
        private ThanhToanBLL bll;
        public frmThanhToan()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
        }


        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {

            if (!bll.IsValidThanhToan(txtMSSV.Text, txtSoTienThanhToan.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ghiChu = bll.ChuanHoaGhiChu(txtGhiChu.Text);
            txtGhiChu.Text = ghiChu;
            string soTienText = txtSoTienThanhToan.Text.Replace(",", "").Replace("₫", "").Trim();
            decimal soTien;
            if (!decimal.TryParse(soTienText, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ, vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThanhToanDTO thanhtoan = new ThanhToanDTO(txtMSSV.Text, txtSoPhong.Text, txtHoTen.Text,cbbLoaiThanhToan.Text,dtpNgayThanhToan.Value,soTien,txtGhiChu.Text);

           

            try
            {
                // Cập nhật dữ liệu vào cơ sở dữ liệu
                bll.SaveThanhToan(thanhtoan);
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtHoTen.Text = "";
            txtGhiChu.Text = "";
            txtSoPhong.Text = "";
            txtSoTienThanhToan.Text = "";
            dtpNgayThanhToan.Value = DateTime.Now;
            cbbLoaiThanhToan.SelectedIndex = -1;
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã số sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SinhVienDTO sinhVien = bll.GetSinhVienByMSSV(txtMSSV.Text);
            if (sinhVien != null)
            {
                txtHoTen.Text = sinhVien.HoTen;
                txtSoPhong.Text = sinhVien.SoPhong;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với MSSV: " + txtMSSV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSoTienThanhToan_Leave(object sender, EventArgs e)
        {
            decimal soTien;
            if (decimal.TryParse(txtSoTienThanhToan.Text, out soTien))
            {
                txtSoTienThanhToan.Text = soTien.ToString("C", new CultureInfo("vi-VN"));
            }
            else
            {
                MessageBox.Show("Số tiền không hợp lệ.");

            }
        }
    }
}
