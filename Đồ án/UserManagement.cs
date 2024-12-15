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
        private DataTable dtNguoiDung;
        private DataTable dtDiaChi;
        private SqlDataAdapter adapterNguoiDung;
        private SqlDataAdapter adapterDiaChi;
        public frmQLNguoiDung()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsNguoiDung = new DataSet();
            cbbTinh.SelectedIndexChanged += cbbTinh_SelectedIndexChanged;
            LoadTinh();
        }

        private void frmQLNguoiDung_Load(object sender, EventArgs e)
        {
            string queryNguoiDung = "select * from nguoidung";
            string queryDiaChi = "select * from diachind";
            adapterNguoiDung = new SqlDataAdapter(queryNguoiDung, ConnectionManager.GetConnection());
            adapterDiaChi = new SqlDataAdapter(queryDiaChi, ConnectionManager.GetConnection());
            adapterNguoiDung.Fill(dsNguoiDung, "nguoidung");
            adapterDiaChi.Fill(dsNguoiDung, "diachind");
            dtNguoiDung = dsNguoiDung.Tables["nguoidung"];
            dtDiaChi = dsNguoiDung.Tables["diachind"];

            // Đặt PrimaryKey cho các bảng
            dtNguoiDung.PrimaryKey = new DataColumn[] { dtNguoiDung.Columns["userid"] };
            dtDiaChi.PrimaryKey = new DataColumn[] { dtDiaChi.Columns["userid"] };

            // Thiết lập mối quan hệ giữa các bảng
            DataRelation relation = new DataRelation("NguoiDung_DiaChi", dtNguoiDung.Columns["userid"], dtDiaChi.Columns["userid"]);
            dsNguoiDung.Relations.Add(relation);
            SqlCommandBuilder cmddc = new SqlCommandBuilder(adapterDiaChi);
            SqlCommandBuilder cmdnd = new SqlCommandBuilder(adapterNguoiDung);
            adapterDiaChi.DeleteCommand = new SqlCommand("delete from diachind where userid = @userid", ConnectionManager.GetConnection());
            adapterDiaChi.DeleteCommand.Parameters.Add("@userid", SqlDbType.VarChar, 50, "userid");
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

            return true;
        }
        private bool KTUseridTrung()
        {
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
            if (KTUseridTrung()==false)
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

        private void LoadTinh()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT TinhID, TenTinh FROM Tinh";  // Câu truy vấn lấy tất cả các tỉnh
                SqlDataAdapter daTinh = new SqlDataAdapter(query, conn);
                DataTable dtTinh = new DataTable();
                daTinh.Fill(dtTinh);

                cbbTinh.DataSource = dtTinh;
                cbbTinh.DisplayMember = "TenTinh";  // Hiển thị tên tỉnh
                cbbTinh.ValueMember = "TinhID";    // Lưu giá trị là mã tỉnh
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadHuyen(int maTinh)
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT HuyenID, TenHuyen FROM huyen WHERE TinhID = @TinhID";  // Lọc các huyện theo mã tỉnh
                SqlDataAdapter daHuyen = new SqlDataAdapter(query, conn);
                daHuyen.SelectCommand.Parameters.AddWithValue("@TinhID", maTinh);
                DataTable dtHuyen = new DataTable();
                daHuyen.Fill(dtHuyen);

                cbbQuanHuyen.DataSource = dtHuyen;
                cbbQuanHuyen.DisplayMember = "TenHuyen";  // Hiển thị tên huyện
                cbbQuanHuyen.ValueMember = "HuyenID";    // Lưu giá trị là mã huyện
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void cbbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTinh.SelectedIndex != -1)
            {
                // Lấy DataRowView từ SelectedItem
                DataRowView selectedRow = (DataRowView)cbbTinh.SelectedItem;

                // Lấy giá trị TinhID từ DataRowView
                int matinh = Convert.ToInt32(selectedRow["TinhID"]);

                LoadHuyen(matinh);
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
            DataRow rowToDelete = dtNguoiDung.Rows.Find(txtMaND.Text);
            if (rowToDelete != null)
            {
                DataRow rowDiaChiToDelete = dtDiaChi.Select($"userid = '{txtMaND.Text}'")[0];
                if (rowDiaChiToDelete != null)
                {
                    rowDiaChiToDelete.Delete();
                    
                }
                rowToDelete.Delete();
                MessageBox.Show("Dữ liệu đã được xóa khỏi DataSet.");
            }
            else
            {
                MessageBox.Show("Mã người dùng không tồn tại trong DataSet.");
            }

        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraTTConTrol() == false)
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
            DialogResult result = MessageBox.Show("Bạn có chắc muốn muốn hoàn tác không", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsNguoiDung.RejectChanges();
                btnClear_Click(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (dsNguoiDung.HasChanges(DataRowState.Added))
                        {
                            adapterNguoiDung.Update(dsNguoiDung.GetChanges(DataRowState.Added),"nguoidung");
                            adapterDiaChi.Update(dsNguoiDung.GetChanges(DataRowState.Added), "diachind");
                        }
                        if (dsNguoiDung.HasChanges(DataRowState.Modified))
                        {
                            adapterNguoiDung.Update(dsNguoiDung.GetChanges(DataRowState.Modified), "nguoidung");
                            adapterDiaChi.Update(dsNguoiDung.GetChanges(DataRowState.Modified), "diachind");
                        }
                        if (dsNguoiDung.HasChanges(DataRowState.Deleted))
                        {
                            adapterDiaChi.Update(dsNguoiDung.GetChanges(DataRowState.Deleted), "diachind");
                            adapterNguoiDung.Update(dsNguoiDung.GetChanges(DataRowState.Deleted), "nguoidung");
                        }
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
                        transaction.Dispose();
                        conn.Close();
                    }
                }
            }
        }
    }
}
