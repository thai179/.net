using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class YeuCauBaoTriBLL
    {
        private YeuCauBaoTriDAL yeuCauDAL = new YeuCauBaoTriDAL();

        public void GuiYeuCau(YeuCauBaoTriDTO yeuCau)
        {
            yeuCauDAL.GuiYeuCau(yeuCau);
        }

        public bool ChuanHoaYeuCau(string moTaVanDe, string soPhong, string doUuTien)
        {
            return !string.IsNullOrEmpty(moTaVanDe) && !string.IsNullOrEmpty(soPhong) && !string.IsNullOrEmpty(doUuTien);
        }
        public string KiemTraThongTin(YeuCauBaoTriDTO yeucau)
        {
            if (yeucau.MoTaVanDe == "")
            {
                return "Ban chua mo ta van de ban gap";
            }
            if (yeucau.SoPhong == "")
            {
                return "ban chua nhap so phong";
            }
            if (yeucau.DoUuTien == "")
            {
                return "Ban chua chon do uu tien";
            }
            return null;
        }
    }
}
