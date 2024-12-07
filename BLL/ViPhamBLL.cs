using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ViPhamBLL
    {
        private ViPhamDAL viPhamDAL;

        public ViPhamBLL()
        {
            viPhamDAL = new ViPhamDAL();
        }

        public string ChuanHoaMoTa(string moTa)
        {
            moTa = moTa.Trim();
            moTa = moTa.ToLower();
            moTa = string.Join(". ", moTa.Split('.').Select(s => s.Trim()).Select(s => char.ToUpper(s[0]) + s.Substring(1)));
            return moTa;
        }

        public void LoadViPhamDataSet()
        {
            viPhamDAL.LoadViPhamData();
        }

        public void AddViPhamToDataSet(string mssv, string hoTen, string soPhong, string moTaViPham, string hinhThucXuLy)
        {
            viPhamDAL.AddViPham(mssv, hoTen, soPhong, moTaViPham, hinhThucXuLy);
        }

        public void SaveChanges()
        {
            viPhamDAL.SaveChanges();
        }

        public DataTable GetSinhVienByMSSV(string mssv)
        {
            return viPhamDAL.GetSinhVienByMSSV(mssv);
        }
        public void UndoChanges()
        {
            viPhamDAL.UndoChanges();
        }
    }
}
