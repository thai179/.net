using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThanhToanBLL
    {
        private ThanhToanDAL dal;


        // Kiểm tra tính hợp lệ của thông tin thanh toán
        public bool IsValidThanhToan(string mssv, string soTien)
        {
            if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(soTien))
                return false;

            decimal soTienDecimal;
            return decimal.TryParse(soTien, out soTienDecimal);
        }

        // Chuyển hóa ghi chú
        public string ChuanHoaGhiChu(string ghiChu)
        {
            ghiChu = ghiChu.Trim();
            ghiChu = ghiChu.ToLower();
            ghiChu = string.Join(". ", ghiChu.Split('.').Select(s => s.Trim()).Select(s => char.ToUpper(s[0]) + s.Substring(1)));
            return ghiChu;
        }

        // Lấy thông tin sinh viên từ mã số sinh viên
        public SinhVienDTO GetSinhVienByMSSV(string mssv)
        {
            return dal.GetSinhVienByMSSV(mssv);
        }

        // Lưu thông tin thanh toán vào cơ sở dữ liệu
        public void SaveThanhToan(ThanhToanDTO thanhtoan)
        {
            dal.SaveThanhToan(thanhtoan);
        }
    }
}
