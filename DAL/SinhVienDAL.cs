using Đồ_án;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SinhVienDAL
    {
        private DataSet dsSinhVien;


        public SinhVienDAL()
        {
            dsSinhVien = new DataSet();
        }

        // Lấy dữ liệu từ CSDL vào DataSet
        public void LoadSV()
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                string query = "SELECT * FROM sinhvien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlDataAdapter adapterDiaChi = new SqlDataAdapter("SELECT * FROM diachisv", ConnectionManager.GetConnection());
                adapter.Fill(dsSinhVien, "SinhVien");
                adapterDiaChi.Fill(dsSinhVien, "DiaChi");
            }
        }
        public DataRow[] CheckMaSVExist( string masv)
        {
            return dsSinhVien.Tables["SinhVien"].Select("masv = '" + masv + "'");
        }

        // Kiểm tra sự tồn tại của CCCD
        public DataRow[] CheckCCCDExist(string cccd)
        {
            return dsSinhVien.Tables["SinhVien"].Select("cccd = '" + cccd + "'");
        }

        // Thêm dữ liệu vào DataSet
        public void AddSinhVien(SinhVienDTO sinhvien)
        {
            DataRow newRow = dsSinhVien.Tables["SinhVien"].NewRow();
            newRow["masv"] = sinhvien.MSSV;
            newRow["hoten"] = sinhvien.HoTen;
            newRow["ngaysinh"] = sinhvien.NgaySinh;
            newRow["gioitinh"] = sinhvien.GioiTinh;
            newRow["cccd"] = sinhvien.CCCD;
            newRow["sdt"] = sinhvien.SDT;
            newRow["sophong"] = sinhvien.SoPhong;

            dsSinhVien.Tables["SinhVien"].Rows.Add(newRow);
            // Thêm địa chỉ sinh viên vào DataTable diachisv
            DataRow newDiaChiRow = dsSinhVien.Tables["DiaChi"].NewRow();
            newDiaChiRow["masv"] = sinhvien.MSSV;
            newDiaChiRow["tinh"] = sinhvien.Tinh;
            newDiaChiRow["huyen_tp"] = sinhvien.HuyenTP;
            newDiaChiRow["sonha"] = sinhvien.SoNha;

            dsSinhVien.Tables["DiaChi"].Rows.Add(newDiaChiRow);
        }

        // Cập nhật dữ liệu trong DataSet
        public void UpdateSinhVien(SinhVienDTO sv)
        {
            DataRow row = dsSinhVien.Tables["SinhVien"].Select("MSSV = '" + sv.MSSV + "'").FirstOrDefault();
            if (row != null)
            {
                row["hoten"] = sv.HoTen;
                row["ngaysinh"] = sv.NgaySinh;
                row["gioitinh"] = sv.GioiTinh;
                row["cccd"] = sv.CCCD;
                row["sdt"] = sv.SDT;
                row["sophong"] = sv.SoPhong;
            }
            DataRow diaChiRow = dsSinhVien.Tables["DiaChi"].Rows.Find(sv.MSSV);
            if (diaChiRow != null)
            {
                diaChiRow["tinh"] = sv.Tinh;
                diaChiRow["huyen_tp"] = sv.HuyenTP;
                diaChiRow["sonha"] = sv.SoNha;
            }
        }

        // Xóa dữ liệu từ DataSet
        public void DeleteSinhVien(string mssv)
        {
            DataRow row = dsSinhVien.Tables["SinhVien"].Select("masv = '" + mssv + "'").FirstOrDefault();
            if (row != null)
            {
                dsSinhVien.Tables["SinhVien"].Rows.Remove(row);
            }
        }
        public DataTable TimSinhVienByMaSV(string masv)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT sv.hoten, sv.ngaysinh, sv.gioitinh, sv.cccd, sv.sdt, sv.sophong, " +
                               "dc.tinh, dc.huyen_tp, dc.sonha " +
                               "FROM sinhvien sv " +
                               "JOIN diachisv dc ON sv.masv = dc.masv " +
                               "WHERE sv.masv = @masv";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@masv", masv);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public void Undo()
        {
            dsSinhVien.RejectChanges();
        }

        // Lưu dữ liệu từ DataSet vào cơ sở dữ liệu
        public bool SaveSinhVienData()
        {
            try
            {
                using (SqlConnection conn = ConnectionManager.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        bool dataChanged = false;

                        // Cập nhật bảng sinhvien
                        foreach (DataRow row in dsSinhVien.Tables["SinhVien"].Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                string updateSinhVienSql = "UPDATE sinhvien SET " +
                                    "hoten = @hoten, ngaysinh = @ngaysinh, gioitinh = @gioitinh, " +
                                    "cccd = @cccd, sdt = @sdt, sophong = @sophong, userid = @userid " +
                                    "WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(updateSinhVienSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                                    cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                                    cmd.Parameters.AddWithValue("@gioitinh", row["gioitinh"]);
                                    cmd.Parameters.AddWithValue("@cccd", row["cccd"]);
                                    cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                                    cmd.Parameters.AddWithValue("@sophong", row["sophong"]);
                                    cmd.Parameters.AddWithValue("@userid", row["userid"]);
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;
                                }
                            }
                            else if (row.RowState == DataRowState.Added)
                            {
                                string insertSinhVienSql = "INSERT INTO sinhvien (masv, hoten, ngaysinh, gioitinh, cccd, sdt, sophong, userid) " +
                                    "VALUES (@masv, @hoten, @ngaysinh, @gioitinh, @cccd, @sdt, @sophong, @userid)";

                                using (SqlCommand cmd = new SqlCommand(insertSinhVienSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);
                                    cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                                    cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                                    cmd.Parameters.AddWithValue("@gioitinh", row["gioitinh"]);
                                    cmd.Parameters.AddWithValue("@cccd", row["cccd"]);
                                    cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                                    cmd.Parameters.AddWithValue("@sophong", row["sophong"]);
                                    cmd.Parameters.AddWithValue("@userid", row["userid"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;
                                }
                            }
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                string deleteSinhVienSql = "DELETE FROM sinhvien WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(deleteSinhVienSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv", DataRowVersion.Original]);
                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;
                                }
                            }
                        }

                        // Cập nhật bảng diachisv
                        foreach (DataRow row in dsSinhVien.Tables["DiaChi"].Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                string updateDiaChiSql = "UPDATE diachisv SET " +
                                    "tinh = @tinh, huyen_tp = @huyen_tp, sonha = @sonha " +
                                    "WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(updateDiaChiSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                                    cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                                    cmd.Parameters.AddWithValue("@sonha", row["sonha"]);
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;
                                }
                            }
                            else if (row.RowState == DataRowState.Added)
                            {
                                string insertDiaChiSql = "INSERT INTO diachisv (masv, tinh, huyen_tp, sonha) " +
                                    "VALUES (@masv, @tinh, @huyen_tp, @sonha)";

                                using (SqlCommand cmd = new SqlCommand(insertDiaChiSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv"]);
                                    cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                                    cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                                    cmd.Parameters.AddWithValue("@sonha", row["sonha"]);

                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;
                                }
                            }
                            else if (row.RowState == DataRowState.Deleted)
                            {
                                string deleteDiaChiSql = "DELETE FROM diachisv WHERE masv = @masv";

                                using (SqlCommand cmd = new SqlCommand(deleteDiaChiSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@masv", row["masv", DataRowVersion.Original]);
                                    cmd.ExecuteNonQuery();
                                    dataChanged = true;
                                }
                            }
                        }

                        // Nếu có thay đổi, commit giao dịch
                        if (dataChanged)
                        {
                            transaction.Commit();
                            return true; // Thành công
                        }
                        else
                        {
                            return false; // Không có thay đổi
                        }
                    }
                    catch
                    {
                        // Rollback giao dịch nếu có lỗi
                        transaction.Rollback();
                        return false; // Thất bại
                    }
                }
            }
            catch (Exception)
            {
                return false; // Thất bại kết nối
            }
        }
    }
}
