using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmPhanHoi : Form
    {
        int tmp = 0;
        public frmPhanHoi()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            string query = "select hoten, sdt from sinhvien where masv = @mssv";
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mssv", txtMSSV.Text);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string hoten = reader["hoten"].ToString();
                        string sdt = reader["sdt"].ToString();

                        // Xử lý dữ liệu ở đây
                        txtHoTen.Text = hoten;
                        txtSDT.Text = sdt;
                    }
                    else
                    {
                        MessageBox.Show("Sinh viên không tồn tại.");
                    }
                }
            }
        }

        private void btnGuiPhanHoi_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sô sinh viên");
                txtMSSV.Focus();
                return;
            }
            if (txtYKien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ý kiến của bạn");
                txtYKien.Focus();
                return;
            }
            if (tmp == 0)
            {
                MessageBox.Show("Bạn chưa đánh giá sao");
                return;
            }
            string query = "insert into phanhoivadanhgia (masv,sosao,hoten,ykien) values(@mssv,@sosao,@hoten,@ykien)";
            
            try
            {
                using (SqlConnection conn = ConnectionManager.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mssv", txtMSSV.Text);
                    cmd.Parameters.AddWithValue("@sosao", tmp);
                    cmd.Parameters.AddWithValue("@hoten",txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@ykien", txtYKien.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                MessageBox.Show("Đánh giả đã gửi thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi phát sinh"+ex);
            }

        }

        private void ptbRong1_Click(object sender, EventArgs e)
        {
            tmp = 1;
            ptbRong1.Hide();
            ptbRong2.Show();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbRong2_Click(object sender, EventArgs e)
        {
            tmp = 2;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbRong3_Click(object sender, EventArgs e)
        {
            tmp = 3;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Hide();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbRong4_Click(object sender, EventArgs e)
        {
            tmp = 4;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Hide();
            ptbRong4.Hide();
            ptbRong5.Show();
        }

        private void ptbRong5_Click(object sender, EventArgs e)
        {
            tmp = 5;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Hide();
            ptbRong4.Hide();
            ptbRong5.Hide();
        }

        private void ptbSao1_Click(object sender, EventArgs e)
        {
            tmp = 1;
            ptbSao1.Show();
            ptbRong2.Show();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbSao2_Click(object sender, EventArgs e)
        {
            tmp = 2;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbSao3_Click(object sender, EventArgs e)
        {
            tmp = 3;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbSao3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbSao4_Click(object sender, EventArgs e)
        {
            tmp = 4;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbSao3.Show();
            ptbSao4.Show();
            ptbRong5.Show();
        }

        private void ptbSao5_Click(object sender, EventArgs e)
        {
            tmp = 1;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbSao3.Show();
            ptbSao4.Show();
            ptbSao5.Show();
        }
    }
}
