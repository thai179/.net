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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Sử dụng ConnectionManager để lấy kết nối
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                // Câu lệnh SQL để kiểm tra tài khoản và mật khẩu
                string query = "SELECT COUNT(*) FROM nguoidung WHERE userid = @Username AND matkhau = @Password";

                try
                {
                    // Thực thi câu lệnh SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Mở kết nối và kiểm tra kết quả
                        connection.Open();
                        int result = (int)command.ExecuteScalar();

                        // Nếu kết quả > 0, đăng nhập thành công
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            if (AuthenticateUser(username, password))
            {
                frmDashboard frmDashboard = new frmDashboard(username);
                this.Hide();
                frmDashboard.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Gọi hàm đăng nhập khi Enter được nhấn
                btnDangNhap_Click(sender, e);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
