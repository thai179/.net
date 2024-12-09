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
    public partial class frmQLPhong : Form
    {

        private DataSet dsPhong;
        private DataSet dsPhongGoc;
        public frmQLPhong()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemPhong themPhong = new frmThemPhong(dsPhong);
            themPhong.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Tạo form sửa phòng
            frmSuaPhong suaPhong = new frmSuaPhong(dsPhong);

            // Kiểm tra nếu có dòng nào được chọn trong DataGridView
            if (dgvHienThi.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvHienThi.SelectedRows[0];

                // Truyền thông tin phòng vào form sửa
                suaPhong.SoPhong= selectedRow.Cells["sophong"].Value.ToString();
                suaPhong.SoNguoi = selectedRow.Cells["sluongtoida"].Value.ToString();
                suaPhong.LoaiPhong = selectedRow.Cells["loaiphong"].Value.ToString();
                suaPhong.TinhTrang = selectedRow.Cells["tinhtrangphong"].Value.ToString();
            }
            

            // Hiển thị form sửa phòng
            suaPhong.ShowDialog();
        }

        private void frmQLPhong_Load(object sender, EventArgs e)
        {
            dsPhong = new DataSet();
            dsPhongGoc = new DataSet();

            string queryPhong = "SELECT * FROM phong";
            string queryUpdateSoluongSv = @"UPDATE phong SET sluongsv = (SELECT COUNT(*) FROM sinhvien WHERE sinhvien.sophong = phong.sophong)";

            string queryUpdateTinhTrangPhong = @"
        UPDATE phong
        SET tinhtrangphong = 
            CASE 
                WHEN sluongsv >= sluongtoida THEN 'Đầy'
                ELSE 'Còn trống'
            END
        WHERE tinhtrangphong != 'Đang bảo trì'
    ";

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();

                // Cập nhật số lượng sinh viên cho mỗi phòng
                using (SqlCommand cmdUpdateSv = new SqlCommand(queryUpdateSoluongSv, conn))
                {
                    cmdUpdateSv.ExecuteNonQuery();
                }

                // Cập nhật tình trạng phòng
                using (SqlCommand cmdUpdateTinhTrang = new SqlCommand(queryUpdateTinhTrangPhong, conn))
                {
                    cmdUpdateTinhTrang.ExecuteNonQuery();
                }

                // Lấy dữ liệu từ bảng phong
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(queryPhong, conn))
                {
                    dataAdapter.Fill(dsPhongGoc, "phong");
                    dsPhong = dsPhongGoc.Copy();
                }

                // Lấy bảng phong từ dataset
                DataTable dataTable = dsPhong.Tables["phong"];

                // Hiển thị dữ liệu lên DataGridView
                dgvHienThi.DataSource = dataTable;
                dgvHienThi.AutoGenerateColumns = true;

                // Đổi tên cột
                dgvHienThi.Columns["sophong"].HeaderText = "Số phòng";
                dgvHienThi.Columns["sluongtoida"].HeaderText = "Số lượng tối đa";
                dgvHienThi.Columns["sluongsv"].HeaderText = "Số lượng sinh viên";
                dgvHienThi.Columns["loaiphong"].HeaderText = "Loại phòng";
                dgvHienThi.Columns["tinhtrangphong"].HeaderText = "Tình Trạng";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHienThi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHienThi.SelectedRows[0];
                if ((int)selectedRow.Cells["sluongsv"].Value != 0 && selectedRow.Cells["sluongsv"].Value != null)
                {
                    MessageBox.Show("Bạn phải xóa hoặc chuyển tất cả sinh viên đi trước khi xóa phòng","Thông báo");
                    return;
                }
                string soPhong = selectedRow.Cells["sophong"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng {soPhong}?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dataTable = dsPhong.Tables["phong"];
                    DataRow rowToDelete = dataTable.AsEnumerable().FirstOrDefault(r => r["sophong"].ToString() == soPhong);

                    if (rowToDelete != null)
                    {
                        rowToDelete.Delete();
                        dgvHienThi.DataSource = dataTable;
                        MessageBox.Show($"Phòng {soPhong}đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hoàn tác không?","Thông báo",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsPhong = dsPhongGoc.Copy();
                dgvHienThi.DataSource = dsPhong.Tables["phong"];
                MessageBox.Show("Hoàn tác thành công!", "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM phong";
            using(SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                try
                {
                    dataAdapter.Update(dsPhong, "phong");
                    dsPhong.AcceptChanges();

                    MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dsPhongGoc = dsPhong.Copy();
        }
    }
}
