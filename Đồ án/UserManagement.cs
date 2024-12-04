using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmQLNguoiDung : Form
    {
        private DataSet dsNguoiDung;
        private DataSet dsNguoiDungGoc;
        private DataTable dtNguoiDung;
        private DataTable dtDiaChi;
        public frmQLNguoiDung()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsNguoiDung = new DataSet();
            dsNguoiDungGoc = new DataSet();
            
        }

        private void frmQLNguoiDung_Load(object sender, EventArgs e)
        {
            string queryNguoiDung = "select * from nguoidung";
            string queryDiaChi = "select * from diachind";
            SqlDataAdapter adapterNguoiDung = new SqlDataAdapter(queryNguoiDung,ConnectionManager.GetConnection());
            SqlDataAdapter adapterDiaChi = new SqlDataAdapter(queryDiaChi, ConnectionManager.GetConnection());
            adapterNguoiDung.Fill(dsNguoiDungGoc,"nguoidung");
            adapterDiaChi.Fill(dsNguoiDungGoc,"diachind");
            dsNguoiDung = dsNguoiDungGoc.Copy();
            dtNguoiDung = dsNguoiDung.Tables["nguoidung"];
            dtDiaChi = dsNguoiDung.Tables["diachind"];

            // Đặt PrimaryKey cho các bảng
            dtNguoiDung.PrimaryKey = new DataColumn[] { dtNguoiDung.Columns["userid"] };
            dtDiaChi.PrimaryKey = new DataColumn[] { dtDiaChi.Columns["userid"] };

            // Thiết lập mối quan hệ giữa các bảng
            DataRelation relation = new DataRelation("NguoiDung_DiaChi", dtNguoiDung.Columns["userid"], dtDiaChi.Columns["userid"]);
            dsNguoiDung.Relations.Add(relation);
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

        private bool KiemTraTTConTrol()
        {
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng.");
                txtMaND.Focus();
                return false;
            }

            if (txtMaND.Text.Contains(" "))
            {
                MessageBox.Show("Mã người dùng không được chứa khoảng trắng.");
                txtMaND.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                txtMatKhau.Focus();
                return false;
            }

            if (txtMatKhau.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng.");
                txtMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                txtHoTen.Focus();
                return false;
            }

            txtHoTen.Text = ChuanHoaTen(txtHoTen.Text);

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                txtSDT.Focus();
                return false;
            }

            string sdtChuan = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            if (!Regex.IsMatch(txtSDT.Text.Trim(), sdtChuan))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbQuyenHan.Text))
            {
                MessageBox.Show("Vui lòng chọn quyền hạn.");
                cbbQuyenHan.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbTinh.Text))
            {
                MessageBox.Show("Vui lòng chọn tỉnh.");
                cbbTinh.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbbQuanHuyen.Text))
            {
                MessageBox.Show("Vui lòng chọn quận/huyện.");
                cbbQuanHuyen.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.");
                txtDiaChi.Focus();
                return false;
            }

            DataRow[] existingRows = dtNguoiDung.Select("userid = '" + txtMaND.Text + "'");
            if (existingRows.Length > 0)
            {
                MessageBox.Show("Mã người dùng đã tồn tại. Vui lòng chọn mã khác.");
                txtMaND.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraTTConTrol() == false)
                return;

            string matKhauMaHoa = MaHoaMatKhau(txtMatKhau.Text);

            DataRow newRow = dtNguoiDung.NewRow();

            newRow["userid"] = txtMaND.Text;
            newRow["matkhau"] = matKhauMaHoa;
            newRow["hoten"] = txtHoTen.Text;
            newRow["ngaysinh"] = dtpNgaySinh.Value;
            newRow["sdt"] = txtSDT.Text;
            newRow["chucvu"] = cbbQuyenHan.Text;

            dtNguoiDung.Rows.Add(newRow);


            DataRow newAddressRow = dtDiaChi.NewRow();

            newAddressRow["userid"] = txtMaND.Text;
            newAddressRow["tinh"] = cbbTinh.Text;
            newAddressRow["huyen_tp"] = cbbQuanHuyen.Text;
            newAddressRow["sonha"] = txtDiaChi.Text;

            dtDiaChi.Rows.Add(newAddressRow);

            MessageBox.Show("Dữ liệu đã được lưu vào DataSet.");
        }

        private string MaHoaMatKhau(string password)
        {
            // Tạo đối tượng MD5
            using (MD5 md5 = MD5.Create())
            {
                // Chuyển mật khẩu thành byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);

                // Mã hóa byte array thành giá trị hash
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển kết quả hash thành chuỗi hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // chuyển đổi byte thành hex string
                }
                return sb.ToString();
            }
        }

        private string ChuanHoaTen(string input)
        {
            // Loại bỏ khoảng trắng thừa ở đầu và cuối
            input = input.Trim();
            // Tạo mảng các phần tử đã được chuẩn hóa
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }

            // Nối lại các từ với nhau, cách nhau bởi khoảng trắng
            return string.Join(" ", words);
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng.");
                txtMaND.Focus();
                return;
            }
            DataRow rowToDelete = dtNguoiDung.Rows.Find(txtMaND.Text);
            if (rowToDelete != null)
            {
                rowToDelete.Delete();

                DataRow rowDiaChiToDelete = dtDiaChi.Rows.Find(txtMaND.Text);
                if (rowDiaChiToDelete != null)
                {
                    rowDiaChiToDelete.Delete();
                }

                MessageBox.Show("Dữ liệu đã được xóa khỏi DataSet.");
            }
            else
            {
                MessageBox.Show("Mã người dùng không tồn tại trong DataSet.");
            }

        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if(KiemTraTTConTrol() == false)
                return;
            string matKhauMaHoa = MaHoaMatKhau(txtMatKhau.Text);
            DataRow rowNguoiDung = dtNguoiDung.Rows.Find(txtMaND.Text); 

            if (rowNguoiDung != null) 
            {

                rowNguoiDung["matkhau"] = matKhauMaHoa;
                rowNguoiDung["hoten"] = txtHoTen.Text;
                rowNguoiDung["ngaysinh"] = dtpNgaySinh.Value;
                rowNguoiDung["sdt"] = txtSDT.Text;
                rowNguoiDung["chucvu"] = cbbQuyenHan.Text;


                DataRow rowDiaChi = dtDiaChi.Rows.Find(txtMaND.Text);

                if (rowDiaChi != null) 
                {

                    rowDiaChi["tinh"] = cbbTinh.Text;
                    rowDiaChi["huyen_tp"] = cbbQuanHuyen.Text;
                    rowDiaChi["sonha"] = txtDiaChi.Text;

                    MessageBox.Show("Thông tin người dùng đã được cập nhật vào DataSet.");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy địa chỉ cho người dùng.");
                }
            }
            else
            {
                MessageBox.Show("Mã người dùng không tồn tại.");
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
                        else MessageBox.Show("Mã người dùng không tồn tại");
                    }
                }
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn muốn hoàn tác không","Thông báo",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                dsNguoiDung = dsNguoiDungGoc.Copy();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Cập nhật bảng nguoidung và diachind
                    UpdateNguoiDungTable(conn, transaction);
                    UpdateDiaChiTable(conn, transaction);

                    // Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Thông tin đã được lưu vào cơ sở dữ liệu thành công.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu dữ liệu vào cơ sở dữ liệu: " + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void UpdateNguoiDungTable(SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                // INSERT vào bảng nguoidung
                foreach (DataRow row in dtNguoiDung.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        string insertQuery = "INSERT INTO nguoidung (userid, matkhau, hoten, ngaysinh, sdt, chucvu) " +
                                             "VALUES (@userid, @matkhau, @hoten, @ngaysinh, @sdt, @chucvu)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@matkhau", row["matkhau"]);
                            cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                            cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                            cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                            cmd.Parameters.AddWithValue("@chucvu", row["chucvu"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh INSERT
                        }
                    }
                }

                // UPDATE bảng nguoidung
                foreach (DataRow row in dtNguoiDung.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        string updateQuery = "UPDATE nguoidung SET matkhau = @matkhau, hoten = @hoten, ngaysinh = @ngaysinh, " +
                                             "sdt = @sdt, chucvu = @chucvu WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@matkhau", row["matkhau"]);
                            cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                            cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                            cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                            cmd.Parameters.AddWithValue("@chucvu", row["chucvu"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh UPDATE
                        }
                    }
                }

                // DELETE từ bảng nguoidung
                foreach (DataRow row in dtNguoiDung.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string deleteQuery = "DELETE FROM nguoidung WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid", DataRowVersion.Original]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh DELETE
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, rollback giao dịch và ném lại lỗi
                transaction.Rollback();
                throw new Exception("Lỗi khi cập nhật bảng nguoidung", ex);
            }
        }

        private void UpdateDiaChiTable(SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                // INSERT vào bảng diachind
                foreach (DataRow row in dtDiaChi.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        string insertQuery = "INSERT INTO diachind (userid, tinh, huyen_tp, sonha) " +
                                             "VALUES (@userid, @tinh, @huyen_tp, @sonha)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                            cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                            cmd.Parameters.AddWithValue("@sonha", row["sonha"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh INSERT
                        }
                    }
                }

                // UPDATE bảng diachind
                foreach (DataRow row in dtDiaChi.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        string updateQuery = "UPDATE diachind SET tinh = @tinh, huyen_tp = @huyen_tp, sonha = @sonha " +
                                             "WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                            cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                            cmd.Parameters.AddWithValue("@sonha", row["sonha"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh UPDATE
                        }
                    }
                }

                // DELETE từ bảng diachind
                foreach (DataRow row in dtDiaChi.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string deleteQuery = "DELETE FROM diachind WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid", DataRowVersion.Original]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh DELETE
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, rollback giao dịch và ném lại lỗi
                transaction.Rollback();
                throw new Exception("Lỗi khi cập nhật bảng diachind", ex);
            }
        }

    }
}
