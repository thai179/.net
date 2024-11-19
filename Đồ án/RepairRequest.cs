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
    public partial class frmBaoTri : Form
    {
        public frmBaoTri()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            if (txtMoTaVanDe.Text == "")
            {
                MessageBox.Show("Ban chua mo ta van de ban gap", "thong bao");
                txtMoTaVanDe.Focus();
                return;
            }
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("ban chua nhap so phong", "thong bao");
                txtSoPhong.Focus();
                return;
            }
            if (cbbDoUuTien.Text == "")
            {
                MessageBox.Show("Ban chua chon do uu tien");
                cbbDoUuTien.Focus();
                return;
            }
            string query = "INSERT INTO yeucaubaotri (sophong, ndyc, douutien) VALUES (@sophong, @ndyc, @douutien)";

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sophong", txtSoPhong.Text);
                cmd.Parameters.AddWithValue("@ndyc",txtMoTaVanDe.Text);
                cmd.Parameters.AddWithValue("@douutien",cbbDoUuTien.Text);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("da gui yeu cau thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ban co chac muon huy khong", "thong bao", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                txtMoTaVanDe.Text = "";
                txtSoPhong.Text = "";
                cbbDoUuTien.SelectedIndex = 0;
                this.Hide();
            }
        }
    }
}
