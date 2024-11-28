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
        private DataSet dsPhong;
        public frmSuaPhong(DataSet ds)
        {
            InitializeComponent();
            this.dsPhong = ds;
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
                MessageBox.Show("ban chua nhap so phong can tim", "thong bao");
                txtSoPhong.Focus();
            }
            else
            {
                DataTable dataTable = dsPhong.Tables["phong"];
                DataRow[] rows = dataTable.Select($"sophong = '{txtSoPhong.Text}'");

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];  // Chọn dòng đầu tiên nếu tìm thấy
                    txtSoNguoi.Text = row["sluongtoida"].ToString();
                    cbbLoaiPhong.Text = row["loaiphong"].ToString();
                    cbbTinhTrang.Text = row["tinhtrangphong"].ToString();
                }
                else
                    {
                        MessageBox.Show("Không tìm thấy thông tin phòng", "Thông báo");
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

            DataTable dataTable = dsPhong.Tables["phong"];
            DataRow[] rows = dataTable.Select($"sophong = '{txtSoPhong.Text}'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];  // Chọn dòng đầu tiên nếu tìm thấy
                row["sluongtoida"] = txtSoNguoi.Text;
                row["loaiphong"] = cbbLoaiPhong.Text;
                row["tinhtrangphong"] = cbbTinhTrang.Text;

                MessageBox.Show("Cập nhật thông tin phòng trong DataSet thành công.", "Thông báo");
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phòng", "Thông báo");
            }
        }

    }
}
