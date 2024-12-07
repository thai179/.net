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
    public class ThongKeBLL
    {
        private ThongKeDAL thongKeDAL;

        public ThongKeBLL()
        {
            thongKeDAL = new ThongKeDAL();
        }

        // Lấy thống kê sinh viên theo phòng
        public List<ThongKeSinhVienDTO> GetThongKeSinhVien()
        {
            return thongKeDAL.GetThongKeSinhVien();
        }

        // Lấy danh sách sinh viên
        public DataTable GetDanhSachSinhVien()
        {
            return thongKeDAL.GetDanhSachSinhVien();
        }

        // Lấy thống kê doanh thu
        public List<ThongKeDoanhThuDTO> GetThongKeDoanhThu(DateTime startDate, DateTime endDate)
        {
            return thongKeDAL.GetThongKeDoanhThu(startDate, endDate);
        }
    }
}
