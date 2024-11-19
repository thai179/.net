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
        public frmViPham()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMoTaViPham.Text = "";
            txtMSSV.Text = "";
            txtSoPhong.Text = "";
            cbbHinhThucXuLy.SelectedIndex = 0;
        }

        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text =="")
            {
                MessageBox.Show("ban chua nhap so phong", "thong bao");
                txtSoPhong.Focus();
                return;
            }
            if (txtMoTaViPham.Text =="")
            {
                MessageBox.Show("ban chua mo ta vi pham cua sinh vien");
                txtMoTaViPham.Focus();
                return;
            }
            if (cbbHinhThucXuLy.Text =="")
            {
                MessageBox.Show("ban chua chon hinh thuc su ly");
                cbbHinhThucXuLy.Focus();
                return;
            }

            string query = "insert into thongtinvipham (ndvp,sophong,mssv,htxuly) values (@ndvp, @sophong, @mssv, @htxuly)";
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ndvp",txtMoTaViPham.Text);
                cmd.Parameters.AddWithValue("@sophong",txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@mssv", txtMSSV.Text);
                cmd.Parameters.AddWithValue("@htxuly",cbbHinhThucXuLy.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("vi pham da duoc ghi nhan");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
                }
            }
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMSSV.Text))
            {
                string mssv = txtMSSV.Text;

                string query = "select hoten, sophong from sinhvien where mssv = @mssv";
                using(SqlConnection conn = ConnectionManager.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query,conn);
                    cmd.Parameters.AddWithValue("@mssv",mssv);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["hoten"].ToString();
                        txtSoPhong.Text = reader["SoPhong"].ToString();
                    }
                    else
                        MessageBox.Show("Ma so sinh vien khong ton tai", "thong bao");
                    reader.Close();
                }
            }
        }
    }
}
