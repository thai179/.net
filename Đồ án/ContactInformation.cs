using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmQLTTLienLac : Form
    {
        DataSet dsThanNhan;
        DataTable dtThanNhan;
        public frmQLTTLienLac()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsThanNhan = new DataSet();
        }

        private void frmQLTTLienLac_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from thannhan",ConnectionManager.GetConnection());
            adapter.Fill(dsThanNhan,"thannhan");
            dtThanNhan = dsThanNhan.Tables["thannhan"];

            dgvThanNhan.DataSource = dtThanNhan;

            dgvThanNhan.Columns["matn"].HeaderText = "Mã TN";
            dgvThanNhan.Columns["masv"].HeaderText = "Mã SV";
            dgvThanNhan.Columns["hoten"].HeaderText = "Họ tên";
            dgvThanNhan.Columns["moiquanhe"].HeaderText = "Mối quan hệ";
            dgvThanNhan.Columns["sdt"].HeaderText = "Số điện thoại";
        }
        private bool KiemTraMSSV(string masv)
        {
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM sinhvien WHERE masv = @masv";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masv", masv);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count == 1;
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo");
                txtMSSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenTN.Text))
            {
                MessageBox.Show("Họ tên người thân không được để trống!", "Thông báo");
                txtTenTN.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbQuanHe.Text))
            {
                MessageBox.Show("Mối quan hệ không được để trống!", "Thông báo");
                cbbQuanHe.Focus();
                return false;
            }
            string sdtChuan = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            if (string.IsNullOrEmpty(txtSDTTN.Text) || !Regex.IsMatch(txtSDTTN.Text.Trim(), sdtChuan))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại!", "Thông báo");
                txtSDTTN.Focus();
                return false;
            }

            return true; // Dữ liệu hợp lệ
        }

        private void ChuanHoaHoTen()
        {
            // Chuẩn hóa họ tên: Xóa khoảng trắng thừa và viết hoa chữ cái đầu
            txtTenTN.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtTenTN.Text.Trim().ToLower());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!KiemTraMSSV(txtMSSV.Text))
            {
                MessageBox.Show("Mã sinh viên không tồn tại. Hãy thêm sinh viên trước","Thông báo");
                txtMSSV.Focus();
                return;
            }
            if(!KiemTraDuLieu())
                return;

            DataRow newRow = dtThanNhan.NewRow();

            newRow["masv"] = txtMSSV.Text;
            newRow["hoten"] = txtTenTN.Text;
            newRow["moiquanhe"] = cbbQuanHe.Text;
            newRow["sdt"] = txtSDTTN.Text;

            dtThanNhan.Rows.Add(newRow);
            dgvThanNhan.DataSource = dtThanNhan;

            MessageBox.Show("Dữ liệu đã được thêm vào bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThanNhan.SelectedRows.Count>0)
            {
                DataGridViewRow row = dgvThanNhan.SelectedRows[0];
                string matn = row.Cells["matn"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thân nhân với mã {matn}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DataRow rowToDelete = dtThanNhan.AsEnumerable().FirstOrDefault(r => r["matn"].ToString() == matn);

                    if (rowToDelete != null)
                    {
                        rowToDelete.Delete();
                        dgvThanNhan.DataSource = dtThanNhan;
                        MessageBox.Show($"Thân nhân {matn}đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThanNhan.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvThanNhan.SelectedRows[0];
                string matn = row.Cells["matn"].Value.ToString();
                DataRow rowToEdit = dtThanNhan.AsEnumerable().FirstOrDefault(r => r["matn"].ToString() == matn);

                if (rowToEdit != null)
                {
                    txtMSSV.Text = rowToEdit["masv"].ToString();
                    txtTenTN.Text = rowToEdit["hoten"].ToString();
                    cbbQuanHe.Text = rowToEdit["moiquanhe"].ToString();
                    txtSDTTN.Text = rowToEdit["sdt"].ToString();

                    rowToEdit["hoten"] = txtTenTN.Text;
                    rowToEdit["moiquanhe"] = cbbQuanHe.Text;
                    rowToEdit["sdt"] = txtSDTTN.Text;

                    dgvThanNhan.DataSource = dtThanNhan;

                    MessageBox.Show("Dữ liệu đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hoàn tác không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsThanNhan.RejectChanges();
                dgvThanNhan.DataSource = dsThanNhan.Tables["thannhan"];
                MessageBox.Show("Hoàn tác thành công!", "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query = "select * from thannhan";
            using(SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                try
                {
                    DataTable changedRows = dsThanNhan.Tables["thannhan"].GetChanges(DataRowState.Added | DataRowState.Modified | DataRowState.Deleted);

                    if (changedRows != null && changedRows.Rows.Count > 0)
                    {
                        // Cập nhật các dòng đã thay đổi
                        adapter.Update(changedRows);

                        // Xác nhận thay đổi trong DataSet
                        dsThanNhan.AcceptChanges();

                        MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có thay đổi nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmQLTTLienLac_Load(sender, e);
        }

        private void txtTenTN_Leave(object sender, EventArgs e)
        {
            ChuanHoaHoTen();
        }
    }
}
