using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanHoiDTO
    {
        public string Masv { get; set; }
        public string HoTen { get; set; }
        public string YKien { get; set; }
        public int SoSao { get; set; }

        public PhanHoiDTO(string masv, string hoten, string ykien, int sosao)
        {
            Masv = masv;
            HoTen = hoten;
            YKien = ykien;
            SoSao = sosao;
        }
    }
}
