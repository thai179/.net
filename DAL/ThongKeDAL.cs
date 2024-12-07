using Đồ_án;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ThongKeDAL
    {
        public List<ThongKeSinhVienDTO> GetThongKeSinhVien()
        {
            List<ThongKeSinhVienDTO> result = new List<ThongKeSinhVienDTO>();
            string query = @"SELECT sophong, COUNT(*) AS SoLuongSinhVien
                        FROM sinhvien
                        GROUP BY sophong";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection()))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ThongKeSinhVienDTO dto = new ThongKeSinhVienDTO
                    {
                        SoPhong = row["sophong"].ToString(),
                        SoLuongSinhVien = Convert.ToInt32(row["SoLuongSinhVien"])
                    };
                    result.Add(dto);
                }
            }
            return result;
        }

        // Lấy danh sách sinh viên
        public DataTable GetDanhSachSinhVien()
        {
            string query = "SELECT masv, hoten, ngaysinh, gioitinh, CCCD, sdt, sophong, userid FROM sinhvien";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());
            DataTable dtSinhVien = new DataTable();
            dataAdapter.Fill(dtSinhVien);
            return dtSinhVien;
        }

        // Lấy thống kê doanh thu trong khoảng thời gian
        public List<ThongKeDoanhThuDTO> GetThongKeDoanhThu(DateTime startDate, DateTime endDate)
        {
            List<ThongKeDoanhThuDTO> result = new List<ThongKeDoanhThuDTO>();
            string query = @"SELECT loai_thanh_toan, SUM(sotien) AS TongTien
                        FROM thanhtoan
                        WHERE ngaylap BETWEEN @startDate AND @endDate
                        GROUP BY loai_thanh_toan";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection()))
            {
                // Thêm tham số để tránh SQL Injection
                adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ThongKeDoanhThuDTO dto = new ThongKeDoanhThuDTO
                    {
                        LoaiThanhToan = row["loai_thanh_toan"].ToString(),
                        TongTien = Convert.ToDecimal(row["TongTien"])
                    };
                    result.Add(dto);
                }
            }
            return result;
        }
    }
}
