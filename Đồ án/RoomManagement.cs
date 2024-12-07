using BLL;
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

        private PhongBLL phongBLL = new PhongBLL();
        public frmQLPhong()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemPhong themPhong = new frmThemPhong();
            themPhong.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Tạo form sửa phòng
            frmSuaPhong suaPhong = new frmSuaPhong();

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
            dgvHienThi.DataSource = phongBLL.GetPhongData();
            dgvHienThi.Columns["sophong"].HeaderText = "Số phòng";
            dgvHienThi.Columns["sluongtoida"].HeaderText = "Số lượng tối đa";
            dgvHienThi.Columns["loaiphong"].HeaderText = "Loại phòng";
            dgvHienThi.Columns["tinhtrangphong"].HeaderText = "Tình Trạng";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHienThi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHienThi.SelectedRows[0];
                string soPhong = selectedRow.Cells["sophong"].Value.ToString();

                phongBLL.DeletePhong(soPhong);
                MessageBox.Show($"Phòng {soPhong} đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hoàn tác không?","Thông báo",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                phongBLL.Undo();
                dgvHienThi.DataSource = phongBLL.GetCurrentDataSet();
                MessageBox.Show("Hoàn tác thành công!", "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (phongBLL.SaveChanges())
            {
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
