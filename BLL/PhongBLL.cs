using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhongBLL
    {
        private PhongDAL phongDAL = new PhongDAL();


        // Lấy dữ liệu phòng từ DAL
        public DataTable GetPhongData()
        {
            return phongDAL.GetPhongData();
        }


        // Thêm phòng vào DAL
        public bool AddPhong(string soPhong, int soNguoi, string loaiPhong, string tinhTrang, out string errorMessage)
        {
            try
            {
                bool result = phongDAL.AddPhong(soPhong, soNguoi, loaiPhong, tinhTrang);
                if (result)
                {
                    errorMessage = string.Empty; // Không có lỗi
                }
                else
                {
                    errorMessage = "Số phòng đã tồn tại.";
                }
                return result;
            }
            catch (Exception ex)
            {
                // Ghi lại thông báo lỗi vào errorMessage
                errorMessage = ex.Message;
                return false;
            }
        }

        // Sửa thông tin phòng trong DAL
        public bool UpdatePhong(string soPhong, int soNguoi, string loaiPhong, string tinhTrang)
        {
            try
            {
                bool result = phongDAL.UpdatePhong(soPhong, soNguoi, loaiPhong, tinhTrang);
                if (result)
                {
                   
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm phòng: {ex.Message}");
            }
        }

        public DataRow FindPhongBySoPhong(string soPhong)
        {
            try
            {
                DataRow row = phongDAL.FindPhongBySoPhong(soPhong);
                if (row != null)
                {
                    return row;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm phòng: {ex.Message}");
            }
        }

        // Xóa phòng trong DAL
        public void DeletePhong(string soPhong)
        {
            phongDAL.DeletePhong(soPhong);
        }

        // Lưu thay đổi vào cơ sở dữ liệu thông qua DAL
        public bool SaveChanges()
        {
            return phongDAL.SaveChanges();
        }

        // Lấy DataSet hiện tại từ DAL
        public DataTable GetCurrentDataSet()
        {
            return phongDAL.GetCurrentDataSet();
        }
        public void Undo()
        {
            phongDAL.Undo();
        }
    }
}
