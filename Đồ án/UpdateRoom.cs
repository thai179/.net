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
        public frmSuaPhong()
        {
            InitializeComponent();
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
                string query = "select sluongtoida,loaiphong,tinhtrangphong FROM phong WHERE sophong = @sophong";
                using (SqlConnection conn = ConnectionManager.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Thêm tham số cho câu truy vấn
                    cmd.Parameters.AddWithValue("@sophong", txtSoPhong.Text);

                    // Mở kết nối
                    conn.Open();

                    // Sử dụng SqlDataReader để đọc dữ liệu
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())  // Kiểm tra có dữ liệu trả về không
                    {
                        string loaiphong = reader["loaiphong"].ToString();
                        string sluongtoida = reader["sluongtoida"].ToString();
                        string tinhtrang = reader["tinhtrangphong"].ToString();

                        txtSoNguoi.Text = sluongtoida;
                        cbbLoaiPhong.Text = loaiphong;
                        cbbTinhTrang.Text = tinhtrang;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin phòng", "Thông báo");
                    }
                }
            }
                
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("ban chua nhap so phong can sửa", "thong bao");
                txtSoPhong.Focus();
                return;

            }
            if (txtSoNguoi.Text == "")
            {
                MessageBox.Show("ban chua nhap so nugoi can sửa", "thong bao");
                txtSoNguoi.Focus();
                return ;
            }
            if (cbbLoaiPhong.Text == "")
            {
                MessageBox.Show("ban chua chon loai can sửa", "thong bao");
                cbbLoaiPhong.Focus();
                return;
            }
            if (cbbTinhTrang.Text == "")
            {
                MessageBox.Show("ban chua chon tinh trang can sửa", "thong bao");
                cbbTinhTrang.Focus();
                return;
            }

            string queryCheck = "SELECT sluongtoida, loaiphong, tinhtrangphong FROM phong WHERE sophong = @sophong";

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                cmdCheck.Parameters.AddWithValue("@sophong", txtSoPhong.Text);

                conn.Open();
                SqlDataReader reader = cmdCheck.ExecuteReader();

                if (!reader.Read())  // Nếu không tìm thấy phòng
                {
                    MessageBox.Show("Số phòng không tồn tại trong cơ sở dữ liệu.", "Thông báo");
                    return;
                }

                // Lưu trữ giá trị hiện tại từ cơ sở dữ liệu
                string currentSluongToida = reader["sluongtoida"].ToString();
                string currentLoaiPhong = reader["loaiphong"].ToString();
                string currentTinhTrang = reader["tinhtrangphong"].ToString();

                // Đóng SqlDataReader
                reader.Close();

                // Kiểm tra xem các giá trị có thay đổi không
                if (currentSluongToida == txtSoNguoi.Text && currentLoaiPhong == cbbLoaiPhong.Text && currentTinhTrang == cbbTinhTrang.Text)
                {
                    // Nếu không có thay đổi, thông báo và không thực hiện update
                    MessageBox.Show("Không có thay đổi nào để cập nhật.", "Thông báo");
                    return;
                }

                // Nếu có thay đổi, thực hiện câu lệnh UPDATE
                string queryUpdate = "UPDATE phong SET sluongtoida = @sluongtoida, loaiphong = @loaiphong, tinhtrangphong = @tinhtrangphong WHERE sophong = @sophong";

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn);
                cmdUpdate.Parameters.AddWithValue("@sophong", txtSoPhong.Text);
                cmdUpdate.Parameters.AddWithValue("@sluongtoida", txtSoNguoi.Text);
                cmdUpdate.Parameters.AddWithValue("@loaiphong", cbbLoaiPhong.Text);
                cmdUpdate.Parameters.AddWithValue("@tinhtrangphong", cbbTinhTrang.Text);

                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Nếu cập nhật thành công
                    MessageBox.Show("Cập nhật thông tin phòng thành công.", "Thông báo");
                }
                else
                {
                    // Nếu cập nhật không thành công
                    MessageBox.Show("Cập nhật không thành công, vui lòng thử lại.", "Thông báo");
                }
            }
        }
    }
}
