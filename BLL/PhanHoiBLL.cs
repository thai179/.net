using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanHoiBLL
    {
        private PhanHoiDAL dal;

        public PhanHoiBLL()
        {
            dal = new PhanHoiDAL();
        }

        // Chuan hoa y kien
        public string ChuanHoaYKien(string yKien)
        {
            yKien = yKien.Trim();
            yKien = yKien.ToLower();
            yKien = string.Join(". ", yKien.Split('.').Select(s => s.Trim()).Select(s => char.ToUpper(s[0]) + s.Substring(1)));
            return yKien;
        }

        public string KiemTraDuLieu(PhanHoiDTO phanhoi)
        {
            if (phanhoi.Masv == "")
            {
                return "Bạn chưa nhập mã sô sinh viên";
            }
            if (phanhoi.YKien == "")
            {
                return "Bạn chưa nhập ý kiến của bạn";
            }
            if (phanhoi.SoSao == 0)
            {
                return "Bạn chưa đánh giá sao";
            }
            return null;
        }

        // Lấy dữ liệu từ DAL
        public void LoadPhanHoi()
        {
            dal.LoadPhanHoi();
        }

        // Thêm phản hồi mới vào DataSet thông qua DTO
        public void AddPhanHoi(PhanHoiDTO phanhoi)
        {
            phanhoi.YKien = ChuanHoaYKien(phanhoi.YKien);
            dal.AddPhanHoi(phanhoi);
        }

        // Lưu phản hồi vào cơ sở dữ liệu
        public void SavePhanHoi()
        {
            dal.SavePhanHoi();
        }

        // Hoàn tác thay đổi
        public void UndoChanges()
        {
            dal.UndoChanges();
        }

        public (string HoTen, string SDT) GetThongTinSinhVien(string masv)
        {
            return dal.GetThongTinSinhVien(masv); // Gọi DAL để lấy thông tin sinh viên
        }
    }
}
