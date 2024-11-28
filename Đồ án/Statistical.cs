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
        public frmThongKe()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            string query = @"SELECT sophong, COUNT(*) AS SoLuongSinhVien
                            FROM sinhvien
                            GROUP BY sophong";

            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            // Cập nhật dữ liệu cho biểu đồ số lượng sinh viên theo phòng
            chartThongKeSinhVien.Series["Sinh Viên"].Points.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string soPhong = row["sophong"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuongSinhVien"]);

                // Thêm điểm vào biểu đồ
                chartThongKeSinhVien.Series["Sinh Viên"].Points.AddXY(soPhong, soLuong);
            }

            DataTable dtSinhVien = new DataTable();

            string querySinhVien = "SELECT masv, hoten, ngaysinh, gioitinh, CCCD, sdt, sophong, userid FROM sinhvien";

            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(querySinhVien, connection);
                    dataAdapter.Fill(dtSinhVien);

                    dgvThongKe.DataSource = dtSinhVien;

                    dgvThongKe.Columns["masv"].HeaderText = "Mã SV";
                    dgvThongKe.Columns["hoten"].HeaderText = "Họ tên";
                    dgvThongKe.Columns["ngaysinh"].HeaderText = "Ngày sinh";
                    dgvThongKe.Columns["gioitinh"].HeaderText = "Giới tính";
                    dgvThongKe.Columns["CCCD"].HeaderText = "Số CCCD";
                    dgvThongKe.Columns["sdt"].HeaderText = "Số điện thoại";
                    dgvThongKe.Columns["sophong"].HeaderText = "Số phòng";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnXuatThongKe_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpBatDau.Value;
            DateTime endDate = dtpKetThuc.Value;

            // Xây dựng câu truy vấn SQL để lấy dữ liệu trong khoảng thời gian
            string query = @"SELECT loai_thanh_toan, SUM(sotien) AS TongTien
                            FROM thanhtoan
                            WHERE ngaylap BETWEEN @startDate AND @endDate
                            GROUP BY loai_thanh_toan";

            // Tạo kết nối và thực hiện truy vấn
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());

            // Thêm tham số để tránh SQL Injection
            adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
            adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Cập nhật dữ liệu cho biểu đồ
            chartThongKeDoanhThu.Series["Thanh Toán"].Points.Clear(); // Clear previous data

            // Thêm dữ liệu vào biểu đồ
            foreach (DataRow row in dt.Rows)
            {
                string loaiThanhToan = row["loai_thanh_toan"].ToString();
                decimal tongTien = Convert.ToDecimal(row["TongTien"]);

                // Thêm điểm vào biểu đồ (tên loại thanh toán và tổng số tiền)
                chartThongKeDoanhThu.Series["Thanh Toán"].Points.AddXY(loaiThanhToan, tongTien);
            }
        }
    }
}
