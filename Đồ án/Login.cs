using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmLogin : Form
    {
        private readonly UserBLL _userBLL;
        public frmLogin()
        {
            InitializeComponent();
            _userBLL = new UserBLL();
        }
        private string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi mảng byte thành chuỗi hex
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            string hashedPassword = GetMD5Hash(password);

            if (_userBLL.AuthenticateUser(username, hashedPassword) == "Sinh viên")
            {
                frmDashboardSV frmDashboardSV = new frmDashboardSV();
                this.Hide();
                frmDashboardSV.ShowDialog();
                this.Show();
            }
            else if (_userBLL.AuthenticateUser(username, hashedPassword) == "Nhân viên")
            {
                frmDashboardNV frmDashboardNV = new frmDashboardNV();
                this.Hide();
                frmDashboardNV.ShowDialog();
                this.Show();
            }
            else if (_userBLL.AuthenticateUser(username, hashedPassword) == "ADMIN")
            {
                frmDashboard frmDashboard = new frmDashboard();
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

    }
}
