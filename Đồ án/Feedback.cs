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
        private DataSet dsPhanHoi;
        private DataSet dsPhanHoiGoc;
        int tmp = 0;
        public frmPhanHoi()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsPhanHoi = new DataSet();
            dsPhanHoiGoc = new DataSet();
        }

        private void frmPhanHoi_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM phanhoivadanhgia";
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());
            adapter.Fill(dsPhanHoiGoc, "PhanHoi");
            dsPhanHoi = dsPhanHoiGoc.Copy();
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

            DataTable dtPhanHoi = dsPhanHoi.Tables["PhanHoi"];
            DataRow newRow = dtPhanHoi.NewRow();
            newRow["masv"] = txtMSSV.Text;
            newRow["sosao"] = tmp;
            newRow["hoten"] = txtHoTen.Text;
            newRow["ykien"] = txtYKien.Text;

            dtPhanHoi.Rows.Add(newRow);

            MessageBox.Show("Đánh giả đã gửi thành công");

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM phanhoivadanhgia", ConnectionManager.GetConnection());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dsPhanHoi, "PhanHoi");

                MessageBox.Show("Dữ liệu đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }

        }

        private void frmHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bận có muốn hoàn tác các thay đổi hay không", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsPhanHoi = dsPhanHoiGoc.Copy();
                MessageBox.Show("Đã hoàn tác các thay đổi.");
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
