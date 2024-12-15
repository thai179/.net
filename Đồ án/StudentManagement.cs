using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmQLSV : Form
    {
        private DataSet dsSinhVien;
        private DataTable dtSinhVien;
        private DataTable dtDiaChi;
        SqlDataAdapter adapterSinhVien;
        SqlDataAdapter adapterDiaChi;
        SqlDataAdapter adapterNguoiDung;
        SqlDataAdapter adapterPhong;
        SqlCommandBuilder builderSinhVien;
        SqlCommandBuilder builderDiaChi;
        SqlCommandBuilder builderNguoiDung;
        SqlCommandBuilder builderPhong;
        public frmQLSV()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsSinhVien = new DataSet();
            cbbTinh.SelectedIndexChanged += cbbTinh_SelectedIndexChanged;
            LoadTinh();
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            adapterSinhVien = new SqlDataAdapter("SELECT * FROM sinhvien", ConnectionManager.GetConnection());
            adapterDiaChi = new SqlDataAdapter("SELECT * FROM diachisv", ConnectionManager.GetConnection());
            adapterNguoiDung = new SqlDataAdapter("SELECT * FROM nguoidung", ConnectionManager.GetConnection());
            adapterPhong = new SqlDataAdapter("SELECT * FROM phong", ConnectionManager.GetConnection());
            adapterSinhVien.Fill(dsSinhVien, "sinhvien");
            adapterDiaChi.Fill(dsSinhVien, "diachisv");
            adapterPhong.Fill(dsSinhVien, "phong");

            dtSinhVien = dsSinhVien.Tables["sinhvien"];
            dtDiaChi = dsSinhVien.Tables["diachisv"];

            dtSinhVien.PrimaryKey = new DataColumn[] { dtSinhVien.Columns["masv"] };
            dtDiaChi.PrimaryKey = new DataColumn[] { dtDiaChi.Columns["masv"] };

            // Thiết lập mối quan hệ giữa các bảng
            DataRelation relation = new DataRelation("NguoiDung_DiaChi", dtSinhVien.Columns["masv"], dtDiaChi.Columns["masv"]);
            dsSinhVien.Relations.Add(relation);
            builderNguoiDung = new SqlCommandBuilder(adapterNguoiDung);
            builderDiaChi = new SqlCommandBuilder(adapterDiaChi);
            builderPhong = new SqlCommandBuilder(adapterPhong);
            builderSinhVien = new SqlCommandBuilder(adapterSinhVien);
            adapterDiaChi.DeleteCommand = new SqlCommand("delete from diachisv where masv = @masv", ConnectionManager.GetConnection());
            adapterDiaChi.DeleteCommand.Parameters.Add("@masv", SqlDbType.VarChar, 50, "masv");
        }

        private bool KiemTraDuLieu()
        {
            // Kiểm tra các TextBox có rỗng không
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống.");
                txtMSSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Họ tên không được để trống.");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("Căn cước công dân không được để trống.");
                txtCCCD.Focus();
                return false;
            }
            if (txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("Cân cước công dân không hợp lệ.");
                txtCCCD.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.");
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
            if (string.IsNullOrEmpty(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống.");
                txtSoPhong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Mã người dùng không được để trống.");
                txtMaND.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChiChiTiet.Text))
            {
                MessageBox.Show("Địa chỉ chi tiết không được để trống.");
                txtDiaChiChiTiet.Focus();
                return false;
            }

            // Kiểm tra ComboBox có được chọn không
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

            // Kiểm tra DateTimePicker có giá trị hợp lệ không
            if (dtpNgaySinh.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.");
                dtpNgaySinh.Focus();
                return false;
            }

            // Kiểm tra RadioButton có được chọn không
            if (!rdbNam.Checked && !rdbNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }

            // Kiểm tra mã sinh viên có trùng không


            ChuanHoaDuLieu();

            return true;
        }
        public bool KiemtraTrungLap()
        {
            DataRow[] existingRows = dtSinhVien.Select("masv = '" + txtMSSV.Text.Trim() + "'");
            if (existingRows.Length > 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng chọn mã khác.");
                txtMSSV.Focus();
                return false;
            }

            DataRow[] existingCCCDRows = dtSinhVien.Select("cccd = '" + txtCCCD.Text.Trim() + "'");
            if (existingCCCDRows.Length > 0)
            {
                MessageBox.Show("CCCD đã tồn tại. Vui lòng kiểm tra lại.");
                txtCCCD.Focus();
                return false;
            }
            return true;
        }

        private void ChuanHoaDuLieu()
        {
            txtMSSV.Text = txtMSSV.Text.Trim();
            txtCCCD.Text = txtCCCD.Text.Trim();

            string[] words = txtName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i].ToLower());
            }
            txtName.Text = string.Join(" ", words);


            txtDiaChiChiTiet.Text = txtDiaChiChiTiet.Text.Trim();

            cbbTinh.Text = cbbTinh.Text.Trim();
            cbbQuanHuyen.Text = cbbQuanHuyen.Text.Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dsSinhVien.Tables[0].Select($"masv ='{txtMSSV.Text.Trim()}'").Length>0)
            {
                MessageBox.Show("Sinh viên đã tồn tại");
                return;

            }
            if (!KiemTraDuLieu())
                return;
            if (!KiemtraTrungLap())
                return;
            DataRow newSinhVienRow = dtSinhVien.NewRow();

            newSinhVienRow["masv"] = txtMSSV.Text;
            newSinhVienRow["hoten"] = txtName.Text;
            newSinhVienRow["ngaysinh"] = dtpNgaySinh.Value;
            newSinhVienRow["gioitinh"] = rdbNam.Checked ? "nam" : "N'nữ'";
            newSinhVienRow["cccd"] = txtCCCD.Text;
            newSinhVienRow["sdt"] = txtSDT.Text;
            newSinhVienRow["sophong"] = txtSoPhong.Text;
            newSinhVienRow["userid"] = txtMaND.Text;

            dtSinhVien.Rows.Add(newSinhVienRow);

            // Thêm địa chỉ sinh viên vào DataTable diachisv
            DataRow newDiaChiRow = dtDiaChi.NewRow();
            newDiaChiRow["masv"] = txtMSSV.Text;
            newDiaChiRow["tinh"] = cbbTinh.Text;
            newDiaChiRow["huyen_tp"] = cbbQuanHuyen.Text;
            newDiaChiRow["sonha"] = txtDiaChiChiTiet.Text;

            dtDiaChi.Rows.Add(newDiaChiRow);

            DataRow rowPhong = dsSinhVien.Tables["phong"].Select($"sophong = '{txtSoPhong.Text}'")[0];
            rowPhong["sluongsv"] = int.Parse(rowPhong["sluongsv"].ToString())+1;
            if (rowPhong["sluongsv"] == rowPhong["sluongtoida"])
                rowPhong["tinhtrang"] = "Đủ người";

            MessageBox.Show("Dữ liệu đã được thêm vào bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }

            // Tìm dòng dữ liệu của sinh viên với mã sinh viên nhập vào
            DataRow sinhVienRow = dtSinhVien.Rows.Find(txtMSSV.Text);
            if (sinhVienRow != null)
            {
                // Xóa dòng sinh viên
                sinhVienRow.Delete();

                // Xóa thông tin địa chỉ của sinh viên tương ứng
                DataRow diaChiRow = dtDiaChi.Rows.Find(txtMSSV.Text);
                if (diaChiRow != null)
                {
                    diaChiRow.Delete();
                }
                // Thông báo đã xóa thành công
                MessageBox.Show("Sinh viên đã được xóa.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã số: " + txtMSSV.Text);
                return;
            }

            // Thông báo yêu cầu nhấn Lưu để lưu vào cơ sở dữ liệu
            MessageBox.Show("Dữ liệu đã được xóa khỏi bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }

            // Tìm dòng dữ liệu của sinh viên với mã sinh viên nhập vào
            DataRow sinhVienRow = dsSinhVien.Tables["sinhvien"].Select($"masv ='{txtMSSV.Text}'")[0];
            if (sinhVienRow != null)
            {
                // Cập nhật các thông tin sinh viên (không thay đổi masv vì nó là khóa chính)
                sinhVienRow["hoten"] = txtName.Text;
                sinhVienRow["ngaysinh"] = dtpNgaySinh.Value;
                sinhVienRow["gioitinh"] = rdbNam.Checked ? "nam" : "nữ'";
                sinhVienRow["cccd"] = txtCCCD.Text;
                sinhVienRow["sdt"] = txtSDT.Text;


                sinhVienRow["sophong"] = txtSoPhong.Text;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã số: " + txtMSSV.Text);
                return;
            }

            // Thông báo yêu cầu nhấn Lưu để lưu vào cơ sở dữ liệu
            MessageBox.Show("Dữ liệu đã được cập nhật trong bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtCCCD.Text = "";
            txtMaND.Text = "";
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
                MessageBox.Show("Bạn chưa nhập mssv", "Thông Báo");
                txtMSSV.Focus();
                return;
            }

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT sv.hoten, sv.ngaysinh, sv.gioitinh, sv.cccd, sv.sdt, sv.sophong, sv.userid, " +
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
                            txtMaND.Text = reader["userid"].ToString();
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

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn hoàn tác không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsSinhVien.EnforceConstraints = false;
                // Làm sạch tất cả các thay đổi trong DataTable
                dtSinhVien.RejectChanges();
                dtDiaChi.RejectChanges();

                // Cập nhật lại các DataTable
                dtSinhVien = dsSinhVien.Tables["sinhvien"];
                dtDiaChi = dsSinhVien.Tables["diachisv"];
                dsSinhVien.EnforceConstraints = true;

                MessageBox.Show("Thao tác hoàn tác thành công.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = ConnectionManager.GetConnection())
                {
                    conn.Open();
                    // Tạo một giao dịch (transaction) để đảm bảo tất cả thay đổi được cập nhật đồng bộ
                    SqlTransaction transaction = conn.BeginTransaction();
                    if (dsSinhVien.HasChanges(DataRowState.Added))
                    {
                        adapterSinhVien.Update(dsSinhVien.GetChanges(DataRowState.Added), "sinhvien");
                        adapterDiaChi.Update(dsSinhVien.GetChanges(DataRowState.Added), "diachisv");
                        adapterPhong.Update(dsSinhVien.GetChanges(DataRowState.Added), "phong");
                    }

                    // 2. Xử lý các bản ghi Update
                    if (dsSinhVien.HasChanges(DataRowState.Modified))
                    {
                        adapterSinhVien.Update(dsSinhVien.GetChanges(DataRowState.Modified), "sinhvien");
                        adapterDiaChi.Update(dsSinhVien.GetChanges(DataRowState.Modified), "diachisv");
                    }

                    // 3. Xử lý các bản ghi Delete
                    if (dsSinhVien.HasChanges(DataRowState.Deleted))
                    {
                        adapterSinhVien.Update(dsSinhVien.GetChanges(DataRowState.Deleted), "sinhvien");
                    }

                    transaction.Commit();
                    MessageBox.Show("Dữ liệu đã được lưu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void LoadTinh()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT TinhID, TenTinh FROM Tinh";
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
    }

}
