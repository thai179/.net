using BLL;
using DTO;
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
    public partial class frmThongKe : Form
    {
        private ThongKeBLL thongKeBLL;

        public frmThongKe()
        {
            InitializeComponent();
            thongKeBLL = new ThongKeBLL(); // Khởi tạo BLL
            this.TopLevel = false;
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // Lấy thông tin sinh viên theo phòng
            List<ThongKeSinhVienDTO> sinhVienList = thongKeBLL.GetThongKeSinhVien();

            // Cập nhật biểu đồ
            chartThongKeSinhVien.Series["Sinh Viên"].Points.Clear();
            foreach (var item in sinhVienList)
            {
                chartThongKeSinhVien.Series["Sinh Viên"].Points.AddXY(item.SoPhong, item.SoLuongSinhVien);
            }

            // Lấy danh sách sinh viên và hiển thị lên DataGridView
            DataTable dtSinhVien = thongKeBLL.GetDanhSachSinhVien();
            dgvThongKe.DataSource = dtSinhVien;

            dgvThongKe.Columns["masv"].HeaderText = "Mã SV";
            dgvThongKe.Columns["hoten"].HeaderText = "Họ tên";
            dgvThongKe.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgvThongKe.Columns["gioitinh"].HeaderText = "Giới tính";
            dgvThongKe.Columns["CCCD"].HeaderText = "Số CCCD";
            dgvThongKe.Columns["sdt"].HeaderText = "Số điện thoại";
            dgvThongKe.Columns["sophong"].HeaderText = "Số phòng";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpBatDau.Value;
            DateTime endDate = dtpKetThuc.Value;

            // Lấy thông tin doanh thu trong khoảng thời gian
            List<ThongKeDoanhThuDTO> doanhThuList = thongKeBLL.GetThongKeDoanhThu(startDate, endDate);

            // Cập nhật biểu đồ
            chartThongKeDoanhThu.Series["Thanh Toán"].Points.Clear();
            foreach (var item in doanhThuList)
            {
                chartThongKeDoanhThu.Series["Thanh Toán"].Points.AddXY(item.LoaiThanhToan, item.TongTien);
            }
        }

        private void btnXuatThongKe_Click(object sender, EventArgs e)
        {
            
        }
    }
}
