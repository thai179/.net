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
        private DataSet dsSinhVien;
        private DataSet dsSinhVienGoc;
        private DataTable dtSinhVien;
        private DataTable dtDiaChi;
        public frmQLSV()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsSinhVien = new DataSet();
            dsSinhVienGoc = new DataSet();
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapterSinhVien = new SqlDataAdapter("SELECT * FROM sinhvien", ConnectionManager.GetConnection());
            SqlDataAdapter adapterDiaChi = new SqlDataAdapter("SELECT * FROM diachisv", ConnectionManager.GetConnection());
            adapterSinhVien.Fill(dsSinhVienGoc, "sinhvien");
            adapterDiaChi.Fill(dsSinhVienGoc, "diachisv");
            dsSinhVien = dsSinhVienGoc.Copy();

            dtSinhVien = dsSinhVien.Tables["sinhvien"];
            dtDiaChi = dsSinhVien.Tables["diachisv"];

            dtSinhVien.PrimaryKey = new DataColumn[] { dtSinhVien.Columns["masv"] };
            dtDiaChi.PrimaryKey = new DataColumn[] { dtDiaChi.Columns["masv"] };

            // Thiết lập mối quan hệ giữa các bảng
            DataRelation relation = new DataRelation("NguoiDung_DiaChi", dtSinhVien.Columns["masv"], dtDiaChi.Columns["masv"]);
            dsSinhVien.Relations.Add(relation);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow newSinhVienRow = dtSinhVien.NewRow();

            newSinhVienRow["masv"] = txtMSSV.Text;
            newSinhVienRow["hoten"] = txtName.Text;
            newSinhVienRow["ngaysinh"] = dtpNgaySinh.Value;
            newSinhVienRow["gioitinh"] = rdbNam.Checked ? "nam" : "nữ";
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
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }

            // Tìm dòng dữ liệu của sinh viên với mã sinh viên nhập vào
            DataRow sinhVienRow = dtSinhVien.Rows.Find(txtMSSV.Text);
            if (sinhVienRow != null)
            {
                // Cập nhật các thông tin sinh viên (không thay đổi masv vì nó là khóa chính)
                sinhVienRow["hoten"] = txtName.Text;
                sinhVienRow["ngaysinh"] = dtpNgaySinh.Value;
                sinhVienRow["gioitinh"] = rdbNam.Checked ? "nam" : "nữ";
                sinhVienRow["cccd"] = txtCCCD.Text;
                sinhVienRow["sdt"] = txtSDT.Text;
                sinhVienRow["sophong"] = txtSoPhong.Text;

                // Thông báo cập nhật thông tin sinh viên thành công
                MessageBox.Show("Thông tin sinh viên đã được cập nhật.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã số: " + txtMSSV.Text);
                return;
            }

            // Cập nhật thông tin địa chỉ
            DataRow diaChiRow = dtDiaChi.Rows.Find(txtMSSV.Text);
            if (diaChiRow != null)
            {
                diaChiRow["tinh"] = cbbTinh.Text;
                diaChiRow["huyen_tp"] = cbbQuanHuyen.Text;
                diaChiRow["sonha"] = txtDiaChiChiTiet.Text;

                // Thông báo cập nhật thông tin địa chỉ thành công
                MessageBox.Show("Thông tin địa chỉ đã được cập nhật.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy địa chỉ của sinh viên này.");
                return;
            }

            // Thông báo yêu cầu nhấn Lưu để lưu vào cơ sở dữ liệu
            MessageBox.Show("Dữ liệu đã được cập nhật trong bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");
        
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

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn hoàn tác không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsSinhVien.EnforceConstraints = false;
                // Làm sạch tất cả các thay đổi trong DataTable
                dtSinhVien.RejectChanges();
                dtDiaChi.RejectChanges();

                // Sao chép lại dữ liệu gốc từ dsSinhVienGoc để khôi phục lại trạng thái ban đầu
                dsSinhVien = dsSinhVienGoc.Copy();

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

                    try
                    {
                        bool dataChanged = false;

                        // Cập nhật bảng sinhvien
                        foreach (DataRow row in dtSinhVien.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                // Cập nhật các thay đổi trên bảng sinhvien
                                string updateSinhVienSql = "UPDATE sinhvien SET " +
                                    "hoten = @hoten, ngaysinh = @ngaysinh, gioitinh = @gioitinh, " +
                                    "cccd = @cccd, sdt = @sdt, sophong = @sophong, userid = @userid " +
                                    "WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(updateSinhVienSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                                    cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                                    cmd.Parameters.AddWithValue("@gioitinh", row["gioitinh"]);
                                    cmd.Parameters.AddWithValue("@cccd", row["cccd"]);
                                    cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                                    cmd.Parameters.AddWithValue("@sophong", row["sophong"]);
                                    cmd.Parameters.AddWithValue("@userid", row["userid"]);
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;  // Có thay đổi
                                }
                            }
                            else if (row.RowState == DataRowState.Added)
                            {
                                // Thêm mới sinh viên vào bảng sinhvien
                                string insertSinhVienSql = "INSERT INTO sinhvien (masv, hoten, ngaysinh, gioitinh, cccd, sdt, sophong, userid) " +
                                    "VALUES (@masv, @hoten, @ngaysinh, @gioitinh, @cccd, @sdt, @sophong, @userid)";

                                using (SqlCommand cmd = new SqlCommand(insertSinhVienSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);
                                    cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                                    cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                                    cmd.Parameters.AddWithValue("@gioitinh", row["gioitinh"]);
                                    cmd.Parameters.AddWithValue("@cccd", row["cccd"]);
                                    cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                                    cmd.Parameters.AddWithValue("@sophong", row["sophong"]);
                                    cmd.Parameters.AddWithValue("@userid", row["userid"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;  // Có thay đổi
                                }
                            }
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                // Xóa sinh viên khỏi bảng sinhvien
                                string deleteSinhVienSql = "DELETE FROM sinhvien WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(deleteSinhVienSql, conn, transaction))
                                {
                                    // Dòng bị xóa có trạng thái Deleted, phải lấy giá trị trước khi xóa
                                    cmd.Parameters.AddWithValue("@masv", row["masv", DataRowVersion.Original]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;  // Có thay đổi
                                }
                            }
                        }

                        // Cập nhật bảng diachisv
                        foreach (DataRow row in dtDiaChi.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                string updateDiaChiSql = "UPDATE diachisv SET " +
                                    "tinh = @tinh, huyen_tp = @huyen_tp, sonha = @sonha " +
                                    "WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(updateDiaChiSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                                    cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                                    cmd.Parameters.AddWithValue("@sonha", row["sonha"]);
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;  // Có thay đổi
                                }
                            }
                            else if (row.RowState == DataRowState.Added)
                            {
                                string insertDiaChiSql = "INSERT INTO diachisv (masv, tinh, huyen_tp, sonha) " +
                                    "VALUES (@masv, @tinh, @huyen_tp, @sonha)";

                                using (SqlCommand cmd = new SqlCommand(insertDiaChiSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);
                                    cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                                    cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                                    cmd.Parameters.AddWithValue("@sonha", row["sonha"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;  // Có thay đổi
                                }
                            }
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                string deleteDiaChiSql = "DELETE FROM diachisv WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(deleteDiaChiSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv", DataRowVersion.Original]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;  // Có thay đổi
                                }
                            }
                        }

                        // Nếu có thay đổi, commit giao dịch
                        if (dataChanged)
                        {
                            transaction.Commit();
                            MessageBox.Show("Dữ liệu đã được lưu thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không có thay đổi nào để lưu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback giao dịch nếu có lỗi
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }



    }
}
