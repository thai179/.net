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
    public class ThanNhanDAL
    {
        private static DataSet dsThanNhan = new DataSet();
        private static DataTable dt = new DataTable();
        public static DataTable GetAllThanNhan()
        {
            string query = "SELECT * FROM thannhan";
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dsThanNhan,"thannhan");
                dt = dsThanNhan.Tables["thannhan"];
                return dt;
            }
        }

        public static DataTable Refresh()
        {
            dt = dsThanNhan.Tables["thannhan"];
            return dt;
        }

        // Thêm mới thân nhân
        public static bool InsertThanNhan(ThanNhanDTO thanNhan)
        {
            DataRow newRow = dsThanNhan.Tables["thannhan"].NewRow();
            newRow["masv"] = thanNhan.Masv;
            newRow["hoten"] = thanNhan.Hoten;
            newRow["moiquanhe"] = thanNhan.Moiquanhe;
            newRow["sdt"] = thanNhan.Sdt;
            dsThanNhan.Tables["thannhan"].Rows.Add(newRow);
            return true;
        }

        // Cập nhật thông tin thân nhân
        public static bool UpdateThanNhan(ThanNhanDTO thanNhan)
        {
            DataRow row = dsThanNhan.Tables["thannhan"].Rows.Find(thanNhan.Matn);
            if (row != null)
            {
                row["hoten"] = thanNhan.Hoten;
                row["moiquanhe"] = thanNhan.Moiquanhe;
                row["sdt"] = thanNhan.Sdt;
                return true;
            }
            return false;
        }

        // Xóa thân nhân theo mã
        public static bool DeleteThanNhan(int matn)
        {
            DataRow row = dsThanNhan.Tables["thannhan"].Rows.Find(matn);
            if (row != null)
            {
                dsThanNhan.Tables["thannhan"].Rows.Remove(row);
                return true;
            }
            return false;
        }
        // Kiểm tra xem sinh vien có tồn tại không
        public static bool KiemTraMSSV(string masv)
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

        public static bool SaveChanges()
        {
            try
            {
                using (SqlConnection conn = ConnectionManager.GetConnection())
                {
                    string query = "SELECT * FROM thannhan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    // Lấy các thay đổi đã xảy ra
                    DataTable changedRows = dsThanNhan.Tables["thannhan"].GetChanges();

                    if (changedRows != null && changedRows.Rows.Count > 0)
                    {
                        // Cập nhật các thay đổi vào cơ sở dữ liệu
                        adapter.Update(changedRows);
                        // Chấp nhận thay đổi trong DataSet
                        dsThanNhan.AcceptChanges();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw new Exception("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
            return false;
        }
        public static void UndoChanges()
        {
            dsThanNhan.RejectChanges();
        }
    }
}
