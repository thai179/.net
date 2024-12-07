using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmViPham : Form
    {
        private ViPhamBLL viPhamBLL;

        public frmViPham()
        {
            InitializeComponent();
            this.TopLevel = false;
            
            viPhamBLL = new ViPhamBLL();
            viPhamBLL.LoadViPhamDataSet();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMoTaViPham.Text = "";
            txtMSSV.Text = "";
            txtSoPhong.Text = "";
            cbbHinhThucXuLy.SelectedIndex = -1;
        }


        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số phòng", "Thông báo");
                txtSoPhong.Focus();
                return;
            }
            if (txtMoTaViPham.Text == "")
            {
                MessageBox.Show("Bạn chưa mô tả vi phạm của sinh viên");
                txtMoTaViPham.Focus();
                return;
            }
            if (cbbHinhThucXuLy.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hình thức xử lý");
                cbbHinhThucXuLy.Focus();
                return;
            }

            string moTa = viPhamBLL.ChuanHoaMoTa(txtMoTaViPham.Text);
            string mssv = txtMSSV.Text;
            string hoTen = txtHoTen.Text;
            string soPhong = txtSoPhong.Text;
            string hinhThucXuLy = cbbHinhThucXuLy.Text;

            viPhamBLL.AddViPhamToDataSet(mssv, hoTen, soPhong, moTa, hinhThucXuLy);
            MessageBox.Show("Vi phạm đã được ghi nhận vào DataSet");
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMSSV.Text))
            {
                string mssv = txtMSSV.Text;
                DataTable dt = viPhamBLL.GetSinhVienByMSSV(mssv);

                if (dt.Rows.Count > 0)
                {
                    txtHoTen.Text = dt.Rows[0]["hoten"].ToString();
                    txtSoPhong.Text = dt.Rows[0]["sophong"].ToString();
                }
                else
                {
                    MessageBox.Show("Mã số sinh viên không tồn tại", "Thông báo");
                }
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hoàn tác các thay đổi hay không", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                viPhamBLL.UndoChanges();
                MessageBox.Show("Đã hoàn tác các thay đổi.");
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                viPhamBLL.SaveChanges();
                MessageBox.Show("Dữ liệu đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu: " + ex.Message);
            }
        }


    }
}
