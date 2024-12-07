using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToanDTO
    {
        public string MSSV { get; set; }
        public string SoPhong { get; set; }
        public string HoTen { get; set; }
        public string LoaiThanhToan { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }

        public ThanhToanDTO(string mssv,string sophong, string hoten, string loaithanhtoan, DateTime ngaylap,decimal sotien, string ghichu)
        {
            MSSV = mssv;
            SoPhong = sophong;
            LoaiThanhToan = loaithanhtoan;
            NgayLap = ngaylap;
            SoTien = sotien;
            GhiChu = ghichu;
        }
    }
}
