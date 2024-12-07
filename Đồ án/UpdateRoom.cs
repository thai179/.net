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
    public partial class frmSuaPhong : Form
    {
        private PhongBLL phongBLL = new PhongBLL();
        public frmSuaPhong()
        {
            InitializeComponent();
        }

        public string SoPhong
        {
            get { return txtSoPhong.Text; }
            set { txtSoPhong.Text = value; }
        }

        public string SoNguoi
        {
            get { return txtSoNguoi.Text; }
            set { txtSoNguoi.Text = value; }
        }

        public string LoaiPhong
        {
            get { return cbbLoaiPhong.Text; }
            set { cbbLoaiPhong.Text = value; }
        }

        public string TinhTrang
        {
            get { return cbbTinhTrang.Text; }
            set { cbbTinhTrang.Text = value; }
        }

        private void btnCLear_Click(object sender, EventArgs e)
        {
            txtSoNguoi.Text = "";
            txtSoPhong.Text = "";
            cbbLoaiPhong.SelectedIndex = -1;
            cbbTinhTrang.SelectedIndex = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ban co muon thoat form khong", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void ptbTim_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số phòng cần tìm", "Thông báo");
                txtSoPhong.Focus();  // Đưa con trỏ vào ô nhập số phòng
            }
            else
            {
                try
                {
                    // Gọi đến lớp BLL để tìm phòng theo số phòng
                    DataRow row = phongBLL.FindPhongBySoPhong(txtSoPhong.Text);

                    // Nếu tìm thấy phòng, cập nhật thông tin lên UI
                    if (row != null)
                    {
                        txtSoNguoi.Text = row["sluongtoida"].ToString();  // Hiển thị số người tối đa
                        cbbLoaiPhong.Text = row["loaiphong"].ToString();  // Hiển thị loại phòng
                        cbbTinhTrang.Text = row["tinhtrangphong"].ToString();  // Hiển thị tình trạng phòng
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng với số phòng đã nhập", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có ngoại lệ khi tìm phòng
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường nhập liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text) || string.IsNullOrWhiteSpace(txtSoNguoi.Text) ||
                string.IsNullOrWhiteSpace(cbbLoaiPhong.Text) || string.IsNullOrWhiteSpace(cbbTinhTrang.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo");
                return;
            }

            // Kiểm tra xem số người có phải là số hợp lệ không
            if (!int.TryParse(txtSoNguoi.Text, out int soNguoi))
            {
                MessageBox.Show("Số người phải là một số hợp lệ.", "Thông báo");
                return;
            }

            bool isUpdated = phongBLL.UpdatePhong(txtSoPhong.Text, soNguoi, cbbLoaiPhong.Text, cbbTinhTrang.Text);

            if (isUpdated)
            {
                MessageBox.Show("Cập nhật thông tin phòng trong DataSet thành công.", "Thông báo");
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng hoặc cập nhật không thành công.", "Thông báo");
            }
        }

    }
}
