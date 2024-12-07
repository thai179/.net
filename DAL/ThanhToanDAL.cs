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
    public class ThanhToanDAL
    {
        public SinhVienDTO GetSinhVienByMSSV(string mssv)
        {
            string query = "SELECT * FROM sinhvien WHERE masv = @masv";
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masv", mssv);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtSinhVien = new DataTable();
                adapter.Fill(dtSinhVien);

                if (dtSinhVien.Rows.Count > 0)
                {
                    DataRow row = dtSinhVien.Rows[0];
                    return new SinhVienDTO
                    {
                        MSSV = row["masv"].ToString(),
                        HoTen = row["hoten"].ToString(),
                        SoPhong = row["sophong"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        // Lưu thông tin thanh toán vào cơ sở dữ liệu
        public void SaveThanhToan(ThanhToanDTO thanhtoan)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM thanhtoan", ConnectionManager.GetConnection());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            // Lấy DataTable từ DataSet để làm việc
            DataTable dtThanhToan = new DataTable();
            adapter.Fill(dtThanhToan);

            // Tạo một DataRow mới
            DataRow newRow = dtThanhToan.NewRow();

            // Chuyển thông tin từ DTO vào DataRow
            newRow["masv"] = thanhtoan.MSSV;
            newRow["sophong"] = thanhtoan.SoPhong;
            newRow["loai_thanh_toan"] = thanhtoan.LoaiThanhToan;
            newRow["ngaylap"] = thanhtoan.NgayLap;
            newRow["sotien"] = thanhtoan.SoTien;
            newRow["ghichu"] = thanhtoan.GhiChu;

            // Thêm DataRow vào DataTable
            dtThanhToan.Rows.Add(newRow);

            try
            {
                // Cập nhật vào cơ sở dữ liệu
                adapter.Update(dtThanhToan);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi cập nhật
                throw new Exception("Lỗi khi cập nhật dữ liệu thanh toán: " + ex.Message);
            }
        }
    }
}
