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
    public partial class frmQLNguoiDung : Form
    {
        public frmQLNguoiDung()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaND.Text = "";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtMatKhau.Text = "";
            cbbQuyenHan.SelectedIndex = -1;
            cbbQuanHuyen.SelectedIndex = -1;
            cbbTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string querynd = "insert into nguoidung (userid, matkhau, hoten, ngaysinh, sdt, chucvu) values (@userid, @matkhau, @hoten, @ngaysinh, @sdt, @quyenhan)";
                    
                    using(SqlCommand cmd1 = new SqlCommand(querynd, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@userid", txtMaND.Text);
                        cmd1.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);
                        cmd1.Parameters.AddWithValue("@hoten",txtHoTen.Text);
                        cmd1.Parameters.AddWithValue("@ngaysinh",dtpNgaySinh.Value);
                        cmd1.Parameters.AddWithValue("@sdt", txtSDT.Text);
                        cmd1.Parameters.AddWithValue("@quyenhan", cbbQuyenHan.Text);

                        cmd1.ExecuteNonQuery();

                        string querydc = "insert into diachind (userid, tinh, huyen_tp, sonha) values (@userid, @tinh, @huyen_tp, @sonha)";

                        using (SqlCommand cmd2 = new SqlCommand(querydc, conn, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@userid", txtMaND.Text);
                            cmd2.Parameters.AddWithValue("@tinh", cbbTinh.Text);
                            cmd2.Parameters.AddWithValue("@huyen_tp", cbbQuanHuyen.Text);
                            cmd2.Parameters.AddWithValue("@sonha", txtDiaChi.Text);

                            cmd2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Thông tin người dùng đã được thêm thành công");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng.");
                txtMaND.Focus();
                return;
            }

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    string query = "DELETE FROM diachind WHERE userid = @mand";
                    using (SqlCommand cmd1 = new SqlCommand(query, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@mand", txtMaND.Text);
                        cmd1.ExecuteNonQuery();
                    }

                    // Xóa dữ liệu trong bảng nguoidung
                    string deleteSinhVien = "DELETE FROM nguoidung WHERE userid = @mand";
                    using (SqlCommand cmd2 = new SqlCommand(deleteSinhVien, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@mand", txtMaND.Text);
                        cmd2.ExecuteNonQuery();
                    }

                    // Commit giao dịch
                    transaction.Commit();
                    MessageBox.Show("Dữ liệu đã được xóa thành công.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex);
                }
                finally
                {
                    conn.Close();
                }

                btnClear_Click(sender, e);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string querynd = "update nguoidung set  matkhau = @matkhau, hoten = @hoten, ngaysinh = @ngaysinh, sdt = @sdt, chucvu = @quyenhan where userid = @userid";

                    using (SqlCommand cmd1 = new SqlCommand(querynd, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@userid", txtMaND.Text);
                        cmd1.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);
                        cmd1.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                        cmd1.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value);
                        cmd1.Parameters.AddWithValue("@sdt", txtSDT.Text);
                        cmd1.Parameters.AddWithValue("@quyenhan", cbbQuyenHan.Text);

                        cmd1.ExecuteNonQuery();

                        string querydc = "UPDATE diachind SET tinh = @tinh, huyen_tp = @huyen_tp, sonha = @sonha WHERE userid = @userid";

                        using (SqlCommand cmd2 = new SqlCommand(querydc, conn, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@userid", txtMaND.Text);
                            cmd2.Parameters.AddWithValue("@tinh", cbbTinh.Text);
                            cmd2.Parameters.AddWithValue("@huyen_tp", cbbQuanHuyen.Text);
                            cmd2.Parameters.AddWithValue("@sonha", txtDiaChi.Text);

                            cmd2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Thông tin người dùng đã được thêm thành công");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ptbTim_Click(object sender, EventArgs e)
        {
            if (txtMaND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã người dùng", "Thông Báo");
                txtMaND.Focus();
                return;
            }
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT nd.hoten, nd.matkhau, nd.ngaysinh, nd.chucvu, nd.sdt, " +
                       "dc.tinh, dc.huyen_tp, dc.sonha " +
                       "FROM nguoidung nd " +
                       "JOIN diachind dc ON nd.userid = dc.userid " +
                       "WHERE nd.userid = @mand";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mand", txtMaND.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hoten = reader["hoten"].ToString();
                            string matkhau = reader["matkhau"].ToString();
                            DateTime ngaysinh = Convert.ToDateTime(reader["ngaysinh"]);
                            string chucvu = reader["chucvu"].ToString();
                            string sdt = reader["sdt"].ToString();
                            string tinh = reader["tinh"].ToString();
                            string huyen_tp = reader["huyen_tp"].ToString();
                            string sonha = reader["sonha"].ToString();

                            txtHoTen.Text = hoten;
                            txtMatKhau.Text = matkhau;
                            dtpNgaySinh.Value = ngaysinh;
                            cbbQuyenHan.Text = chucvu;
                            txtSDT.Text = sdt;
                            cbbTinh.Text = tinh;
                            cbbQuanHuyen.Text = huyen_tp;
                            txtDiaChi.Text = sonha;
                        }
                    }
                }
            }
        }
    }
}
