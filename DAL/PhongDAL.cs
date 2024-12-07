using Đồ_án;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongDAL
    {
        private DataSet dsPhong = new DataSet();
        private DataTable dtPhong =  new DataTable();
        
    
    public DataTable GetPhongData()
        {
            string query = "SELECT * FROM phong";

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn))
                {
                    dataAdapter.Fill(dsPhong, "phong");
                    dtPhong = dsPhong.Tables["phong"];
                }
            }

            return dtPhong;
        }

        public bool AddPhong(string soPhong, int soNguoi, string loaiPhong, string tinhTrang)
        {
            try
            {
                // Kiểm tra số phòng đã tồn tại trong DataSet
                DataRow existingRow = dtPhong.Rows
                    .Cast<DataRow>()
                    .FirstOrDefault(row => row["sophong"].ToString() == soPhong);

                if (existingRow != null)
                {
                    // Nếu phòng đã tồn tại, trả về false
                    return false;
                }

                // Nếu phòng chưa tồn tại, thêm phòng mới
                DataRow newRow = dtPhong.NewRow();
                newRow["sophong"] = soPhong;
                newRow["sluongtoida"] = soNguoi;
                newRow["loaiphong"] = loaiPhong;
                newRow["tinhtrangphong"] = tinhTrang;
                dtPhong.Rows.Add(newRow);

                return true; // Thành công
            }
            catch (Exception)
            {
                // Ném ra lỗi để BLL xử lý
                throw new Exception("Đã xảy ra lỗi khi thêm phòng.");
            }
        }

        // Sửa thông tin phòng trong DataSet
        public bool UpdatePhong(string soPhong, int soNguoi, string loaiPhong, string tinhTrang)
        {
            try
            {
                // Tìm dòng có số phòng tương ứng
                DataRow[] rows = dtPhong.Select($"sophong = '{soPhong}'");

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    row["sluongtoida"] = soNguoi; // Đảm bảo truyền vào kiểu int cho số người tối đa
                    row["loaiphong"] = loaiPhong;
                    row["tinhtrangphong"] = tinhTrang;
                    return true; // Cập nhật thành công
                }
                else
                {
                    return false; // Không tìm thấy số phòng
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật thông tin phòng: {ex.Message}");
            }
        }

        public DataRow FindPhongBySoPhong(string soPhong)
        {
            try
            {
                // Nếu 'sophong' không phải là khóa chính, dùng Select hoặc FirstOrDefault để tìm
                DataRow[] rows = dtPhong.Select($"sophong = '{soPhong}'");

                if (rows.Length > 0)
                {
                    return rows[0]; // Trả về dòng đầu tiên tìm thấy
                }
                else
                {
                    return null; // Không tìm thấy phòng
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm phòng: {ex.Message}");
            }
        }

        // Xóa phòng trong DataSet
        public void DeletePhong(string soPhong)
        {
            DataRow row = dtPhong.Rows.Find(soPhong);
            if (row != null)
            {
                dtPhong.Rows.Remove(row);
            }
        }

        // Lưu thay đổi trong DataSet vào cơ sở dữ liệu
        public bool SaveChanges()
        {
            string query = "SELECT * FROM phong";
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                try
                {
                    dataAdapter.Update(dsPhong, "phong");
                    dsPhong.AcceptChanges();  // Chấp nhận các thay đổi trong DataSet
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        // Hàm hoàn tác
        public void Undo()
        {
            dsPhong.RejectChanges();
        }

        // Hàm để lấy DataSet hiện tại
        public DataTable GetCurrentDataSet()
        {
            dtPhong = dsPhong.Tables[0];
            return dtPhong;
        }
    }
}
