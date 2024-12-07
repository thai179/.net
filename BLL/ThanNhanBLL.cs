using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ThanNhanBLL
    {
        public static bool CheckStudentExist(string masv)
        {
            return ThanNhanDAL.KiemTraMSSV(masv);  // Giả sử hàm kiểm tra mã sinh viên này đã có ở đâu đó trong form
        }

        // Kiểm tra dữ liệu thân nhân có hợp lệ không
        public static string ValidateThanNhanData(string masv, string hoten, string moiquanhe, string sdt)
        {
            if (string.IsNullOrEmpty(masv))
            {
                return "Mã sinh viên không được để trống.";
            }
            if (string.IsNullOrEmpty(hoten))
            {
                return "Họ tên không được để trống.";
            }
            if (string.IsNullOrEmpty(moiquanhe))
            {
                return "Mối quan hệ không được để trống.";
            }
            if (string.IsNullOrEmpty(sdt))
            {
                return "Số điện thoại không được để trống.";
            }
            string sdtChuan = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            if (!Regex.IsMatch(sdt, sdtChuan))
            {
                return "Số điện thoại không hợp lệ. Định dạng hợp lệ là: 0x-xxxxxxxx.";
            }
            return null;
        }

        // Lấy tất cả thân nhân
        public static DataTable GetAllThanNhan()
        {
            return ThanNhanDAL.GetAllThanNhan();
        }

        // Thêm thân nhân mới
        public static bool AddThanNhan(ThanNhanDTO thanNhan)
        {
            return ThanNhanDAL.InsertThanNhan(thanNhan);
        }

        // Cập nhật thông tin thân nhân
        public static bool UpdateThanNhan(ThanNhanDTO thanNhan)
        {
            return ThanNhanDAL.UpdateThanNhan(thanNhan);
        }

        // Xóa thân nhân theo mã
        public static bool DeleteThanNhan(int matn)
        {
            return ThanNhanDAL.DeleteThanNhan(matn);
        }
        // Lưu thay đổi vào cơ sở dữ liệu
        public static bool SaveChanges()
        {
            return ThanNhanDAL.SaveChanges();
        }

        // Hoàn tác thay đổi
        public static void UndoChanges()
        {
            ThanNhanDAL.UndoChanges();
        }
        public static DataTable Refresh()
        {
            return ThanNhanDAL.Refresh();
        }
    }
}
