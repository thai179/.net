using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Security.Cryptography;

namespace BLL
{
    public class NguoiDungBLL
    {
        private NguoiDungDAL nguoiDungDAL;
        public void LoadND()
        {
            nguoiDungDAL = new NguoiDungDAL();
            nguoiDungDAL.LoadND();
        }
        public string MaHoaMatKhau(string password)
        {
            // Tạo đối tượng MD5
            using (MD5 md5 = MD5.Create())
            {
                // Chuyển mật khẩu thành byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);

                // Mã hóa byte array thành giá trị hash
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển kết quả hash thành chuỗi hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // chuyển đổi byte thành hex string
                }
                return sb.ToString();
            }
        }
        public string ChuanHoaTen(string input)
        {
            // Loại bỏ khoảng trắng thừa ở đầu và cuối
            input = input.Trim();
            // Tạo mảng các phần tử đã được chuẩn hóa
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }

            // Nối lại các từ với nhau, cách nhau bởi khoảng trắng
            return string.Join(" ", words);
        }
        public bool KiemTraMaNguoiDung(string maND)
        {
            if (string.IsNullOrEmpty(maND))
            {
                throw new Exception("Mã người dùng không được để trống.");
            }

            // Gọi phương thức DAL để kiểm tra mã người dùng
            return nguoiDungDAL.KiemTraMaNguoiDung(maND);
        }
        public void ThemNguoiDung(NguoiDungDTO nd)
        {
            nguoiDungDAL.ThemNguoiDung(nd);
        }
        public void XoaNguoiDung(string mand)
        {
            nguoiDungDAL.XoaNguoiDung(mand);
        }
        public void SuaNguoiDung(NguoiDungDTO nd)
        {
            nguoiDungDAL.SuaNguoiDung(nd);
        }
        public void Undo()
        {
            nguoiDungDAL.Undo();
        }
        public DataTable TimKiemNguoiDung(string maND)
        {
            if (string.IsNullOrEmpty(maND))
            {
                throw new Exception("Mã người dùng không được để trống.");
            }

            // Gọi DAL để lấy thông tin người dùng từ cơ sở dữ liệu
            return nguoiDungDAL.TimKiemNguoiDung(maND);
        }
        public bool LuuThongTinNguoiDung()
        {
            try
            {
                // Gọi DAL để lưu thông tin người dùng
                return nguoiDungDAL.LuuThongTinNguoiDung();
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, ném ngoại lệ lên lớp gọi (UI)
                throw new Exception("Lỗi trong nghiệp vụ khi lưu thông tin người dùng.", ex);
            }
        }
    }
}
