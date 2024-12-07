using Đồ_án;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanHoiDAL
    {
        private DataSet dsPhanHoi = new DataSet();
        private DataTable dtPhanHoi = new DataTable();

        // Lấy dữ liệu ban đầu từ cơ sở dữ liệu và sao lưu vào DataSet gốc
        public void LoadPhanHoi()
        {
            string query = "SELECT * FROM phanhoivadanhgia";
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());
            adapter.Fill(dsPhanHoi, "PhanHoi");
            dtPhanHoi = dsPhanHoi.Tables[0];
        }

        // Lưu các thay đổi trong DataSet vào cơ sở dữ liệu
        public void SavePhanHoi()
        {
            if (dsPhanHoi.GetChanges() != null)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM phanhoivadanhgia", ConnectionManager.GetConnection());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dsPhanHoi, "PhanHoi");

                dsPhanHoi.AcceptChanges();
            }
        }

        // Hoàn tác các thay đổi chưa lưu
        public void UndoChanges()
        {
            if (dsPhanHoi.GetChanges() != null)
            {
                dsPhanHoi.RejectChanges();
            }
        }

        // Thêm phản hồi mới vào DataSet từ DTO
        public void AddPhanHoi(PhanHoiDTO dto)
        {
            DataRow newRow = dtPhanHoi.NewRow();
            newRow["masv"] = dto.Masv;
            newRow["hoten"] = dto.HoTen;
            newRow["ykien"] = dto.YKien;
            newRow["sosao"] = dto.SoSao;
            dtPhanHoi.Rows.Add(newRow);
        }

        public (string HoTen, string SDT) GetThongTinSinhVien(string masv)
        {
            string hoTen = string.Empty;
            string sdt = string.Empty;
            string query = "SELECT hoten, sdt FROM sinhvien WHERE masv = @masv";

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masv", masv);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hoTen = reader["hoten"].ToString();
                        sdt = reader["sdt"].ToString();
                    }
                }
            }
            return (hoTen, sdt);
        }
    }
}
