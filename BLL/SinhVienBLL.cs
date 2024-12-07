using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    public class SinhVienBLL
    {
        private SinhVienDAL sinhVienDAL;

        public SinhVienBLL()
        {
            sinhVienDAL = new SinhVienDAL();
        }

        // Lấy dữ liệu từ DAL
        public void LoadSV()
        {
            sinhVienDAL.LoadSV();
        }
        public bool IsMaSVExist(string masv)
        {
            DataRow[] existingRows = sinhVienDAL.CheckMaSVExist( masv);
            return existingRows.Length > 0;
        }

        // Kiểm tra CCCD
        public bool IsCCCDExist(string cccd)
        {
            DataRow[] existingCCCDRows = sinhVienDAL.CheckCCCDExist(cccd);
            return existingCCCDRows.Length > 0;
        }

        // Thêm sinh viên vào DataSet
        public void AddSinhVien(SinhVienDTO sv)
        {
            sinhVienDAL.AddSinhVien(sv);
        }

        // Cập nhật sinh viên trong DataSet
        public void UpdateSinhVien(SinhVienDTO sv)
        {
            sinhVienDAL.UpdateSinhVien(sv);
        }

        // Xóa sinh viên trong DataSet
        public void DeleteSinhVien(string mssv)
        {
            sinhVienDAL.DeleteSinhVien(mssv);
        }
        public DataTable TimSinhVienByMaSV(string masv)
        {
            return sinhVienDAL.TimSinhVienByMaSV(masv);
        }
        public void Undo()
        {
            sinhVienDAL.Undo();
        }

        // Lưu dữ liệu vào cơ sở dữ liệu
        public bool SaveSinhVienData()
        {
            return sinhVienDAL.SaveSinhVienData();
        }
    }
}
