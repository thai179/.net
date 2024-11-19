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
    public partial class frmQLSV : Form
    {
        public frmQLSV()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();

                // Tạo giao dịch (transaction)
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Thêm dữ liệu vào bảng sinhvien
                    string insertSinhVien = "INSERT INTO sinhvien (masv,hoten, ngaysinh, gioitinh, cccd, sdt, sophong) " +
                                            "VALUES (@masv, @hoten, @ngaysinh, @gioitinh, @cccd, @sdt, @sophong); ";

                    using (SqlCommand cmd1 = new SqlCommand(insertSinhVien, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@masv", txtMSSV.Text);
                        cmd1.Parameters.AddWithValue("@hoten", txtName.Text); // TextBox chứa họ tên
                        cmd1.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value); // TextBox chứa ngày sinh
                        cmd1.Parameters.AddWithValue("@gioitinh", rdbNam.Checked ? "nam":"nu"); // ComboBox chứa giới tính
                        cmd1.Parameters.AddWithValue("@cccd", txtCCCD.Text); // TextBox chứa CCCD
                        cmd1.Parameters.AddWithValue("@sdt", txtSoPhong.Text); // TextBox chứa số điện thoại
                        cmd1.Parameters.AddWithValue("@sophong", txtSoPhong.Text); // TextBox chứa số phòng

                        cmd1.ExecuteNonQuery();
                        // Thêm dữ liệu vào bảng diachisv
                        string insertDiaChi = "INSERT INTO diachisv (masv, tinh, huyen_tp, sonha) " +
                                              "VALUES (@masv, @tinh, @huyen_tp, @sonha);";

                        using (SqlCommand cmd2 = new SqlCommand(insertDiaChi, conn, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@masv", txtMSSV.Text); // Sử dụng masv đã lấy từ bảng sinhvien
                            cmd2.Parameters.AddWithValue("@tinh", cbbTinh.Text); // TextBox chứa tỉnh
                            cmd2.Parameters.AddWithValue("@huyen_tp", cbbQuanHuyen.Text); // TextBox chứa huyện hoặc thành phố
                            cmd2.Parameters.AddWithValue("@sonha", txtDiaChiChiTiet.Text); // TextBox chứa số nhà

                            // Thực thi câu lệnh
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    // Commit giao dịch
                    transaction.Commit();
                    MessageBox.Show("Dữ liệu đã được chèn thành công.");
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, rollback giao dịch
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối
                    conn.Close();
                }

            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();

                // Tạo giao dịch (transaction) để đảm bảo xóa đồng bộ
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa dữ liệu trong bảng diachisv
                    string deleteDiaChi = "DELETE FROM diachisv WHERE masv = @masv";
                    using (SqlCommand cmd1 = new SqlCommand(deleteDiaChi, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@masv", txtMSSV.Text);
                        cmd1.ExecuteNonQuery();
                    }

                    // Xóa dữ liệu trong bảng sinhvien
                    string deleteSinhVien = "DELETE FROM sinhvien WHERE masv = @masv";
                    using (SqlCommand cmd2 = new SqlCommand(deleteSinhVien, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@masv", txtMSSV.Text);
                        cmd2.ExecuteNonQuery();
                    }

                    // Commit giao dịch
                    transaction.Commit();
                    MessageBox.Show("Dữ liệu đã được xóa thành công.");
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, rollback giao dịch
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối
                    conn.Close();
                }
                btnClear_Click(sender, e);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();

                // Tạo giao dịch (transaction) để đảm bảo cập nhật đồng bộ
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Cập nhật thông tin trong bảng sinhvien
                    string updateSinhVien = "UPDATE sinhvien SET hoten = @hoten, ngaysinh = @ngaysinh, gioitinh = @gioitinh, " +
                                            "cccd = @cccd, sdt = @sdt, sophong = @sophong WHERE masv = @masv";
                    using (SqlCommand cmd1 = new SqlCommand(updateSinhVien, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@masv", txtMSSV.Text);
                        cmd1.Parameters.AddWithValue("@hoten", txtName.Text);
                        cmd1.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value);
                        cmd1.Parameters.AddWithValue("@gioitinh", rdbNam.Checked ? "nam" : "nu");
                        cmd1.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                        cmd1.Parameters.AddWithValue("@sdt", txtSDT.Text);
                        cmd1.Parameters.AddWithValue("@sophong", txtSoPhong.Text);
                        cmd1.ExecuteNonQuery();
                    }

                    // Cập nhật thông tin trong bảng diachisv
                    string updateDiaChi = "UPDATE diachisv SET tinh = @tinh, huyen_tp = @huyen_tp, sonha = @sonha WHERE masv = @masv";
                    using (SqlCommand cmd2 = new SqlCommand(updateDiaChi, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@masv", txtMSSV.Text);
                        cmd2.Parameters.AddWithValue("@tinh", cbbTinh.Text);
                        cmd2.Parameters.AddWithValue("@huyen_tp", cbbQuanHuyen.Text);
                        cmd2.Parameters.AddWithValue("@sonha", txtDiaChiChiTiet.Text);
                        cmd2.ExecuteNonQuery();
                    }

                    // Commit giao dịch
                    transaction.Commit();
                    MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, rollback giao dịch
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối
                    conn.Close();
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtCCCD.Text = "";
            txtDiaChiChiTiet.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
            txtSoPhong.Text = "";
            cbbTinh.SelectedIndex = -1;
            cbbQuanHuyen.SelectedIndex = -1;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }


        private void ptbTim_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mssv","Thông Báo");
                txtMSSV.Focus();
                return;
            }

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT sv.hoten, sv.ngaysinh, sv.gioitinh, sv.cccd, sv.sdt, sv.sophong, " +
                       "dc.tinh, dc.huyen_tp, dc.sonha " +
                       "FROM sinhvien sv " +
                       "JOIN diachisv dc ON sv.masv = dc.masv " +
                       "WHERE sv.masv = @masv";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@masv", txtMSSV.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Nếu có kết quả trả về
                        if (reader.Read())
                        {
                            // Đổ dữ liệu vào các TextBox tương ứng
                            txtName.Text = reader["hoten"].ToString();
                            dtpNgaySinh.Value = Convert.ToDateTime(reader["ngaysinh"]);
                            txtCCCD.Text = reader["cccd"].ToString();
                            txtSDT.Text = reader["sdt"].ToString();
                            txtSoPhong.Text = reader["sophong"].ToString();

                            string gioiTinh = reader["gioitinh"].ToString();
                            if (gioiTinh == "nam")
                                rdbNam.Checked = true;
                            else
                                rdbNu.Checked = true;

                            // Đổ dữ liệu vào địa chỉ
                            cbbTinh.Text = reader["tinh"].ToString();
                            cbbQuanHuyen.Text = reader["huyen_tp"].ToString();
                            txtDiaChiChiTiet.Text = reader["sonha"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên với mã " + txtMSSV.Text);
                        }
                    }
                }
            }
        }
    }
}
