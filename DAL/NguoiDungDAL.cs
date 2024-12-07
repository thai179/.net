using Đồ_án;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NguoiDungDAL
    {
        private DataSet dsNguoiDung = new DataSet();
        private DataTable dtNguoiDung;
        private DataTable dtDiaChiND;
        public void LoadND()
        {
            string queryNguoiDung = "select * from nguoidung";
            string queryDiaChi = "select * from diachind";
            SqlDataAdapter adapterNguoiDung = new SqlDataAdapter(queryNguoiDung, ConnectionManager.GetConnection());
            SqlDataAdapter adapterDiaChi = new SqlDataAdapter(queryDiaChi, ConnectionManager.GetConnection());
            adapterNguoiDung.Fill(dsNguoiDung, "nguoidung");
            adapterDiaChi.Fill(dsNguoiDung, "diachind");
            dtNguoiDung = dsNguoiDung.Tables[0];
            dtDiaChiND = dsNguoiDung.Tables[1];
        }
        public bool KiemTraMaNguoiDung(string maND)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM nguoidung WHERE userid = @mand";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mand", maND);

                    int count = Convert.ToInt32(cmd.ExecuteScalar()); // Trả về số lượng mã người dùng trùng

                    return count > 0; // Nếu có ít nhất 1 người dùng trùng mã, trả về true
                }
            }
        }
        public void ThemNguoiDung(NguoiDungDTO nguoiDungDTO)
        {
            DataRow newRow = dtNguoiDung.NewRow();
            newRow["userid"] = nguoiDungDTO.MaND;
            newRow["matkhau"] = nguoiDungDTO.MatKhau;
            newRow["hoten"] = nguoiDungDTO.HoTen;
            newRow["ngaysinh"] = nguoiDungDTO.NgaySinh;
            newRow["sdt"] = nguoiDungDTO.SDT;
            newRow["chucvu"] = nguoiDungDTO.ChucVu;

            dtNguoiDung.Rows.Add(newRow);

            DataRow newAddressRow = dtDiaChiND.NewRow();

            newAddressRow["userid"] = nguoiDungDTO.MaND;
            newAddressRow["tinh"] = nguoiDungDTO.Tinh;
            newAddressRow["huyen_tp"] = nguoiDungDTO.HuyenTP;
            newAddressRow["sonha"] = nguoiDungDTO.SoNha;

            dtDiaChiND.Rows.Add(newAddressRow);
        }

        public void SuaNguoiDung(NguoiDungDTO nguoiDungDTO)
        {
                DataRow rowNguoiDung = dtNguoiDung.Rows.Find(nguoiDungDTO.MaND);
                if (rowNguoiDung != null)
            {
                rowNguoiDung["matkhau"] = nguoiDungDTO.MatKhau;
                rowNguoiDung["hoten"] = nguoiDungDTO.HoTen;
                rowNguoiDung["ngaysinh"] = nguoiDungDTO.NgaySinh;
                rowNguoiDung["sdt"] = nguoiDungDTO.SDT;
                rowNguoiDung["chucvu"] = nguoiDungDTO.ChucVu;
            }
            DataRow rowDiaChi = dtDiaChiND.Rows.Find(nguoiDungDTO.MaND);
            if (rowDiaChi != null)
            {
                rowDiaChi["tinh"] = nguoiDungDTO.Tinh;
                rowDiaChi["huyen_tp"] = nguoiDungDTO.HuyenTP;
                rowDiaChi["sonha"] = nguoiDungDTO.SoNha;
            }
        }

        public void XoaNguoiDung(string maND)
        {
            DataRow rowNguoiDung = dtNguoiDung.Rows.Find(maND);
            if (rowNguoiDung != null)
            {
                rowNguoiDung.Delete();
            }
            DataRow rowDiaChi = dtDiaChiND.Rows.Find(maND);
            if (rowDiaChi != null)
            {
                rowDiaChi.Delete();
            }
        }
        public void Undo()
        {
            dsNguoiDung.RejectChanges();
        }
        public DataTable TimKiemNguoiDung(string maND)
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                conn.Open();
                string query = "SELECT nd.hoten, nd.matkhau, nd.ngaysinh, nd.chucvu, nd.sdt, " +
                               "dc.tinh, dc.huyen_tp, dc.sonha " +
                               "FROM nguoidung nd " +
                               "JOIN diachind dc ON nd.userid = dc.userid " +
                               "WHERE nd.userid = @mand";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mand", maND);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(resultTable);  // Điền dữ liệu vào DataTable
                    }
                }
            }

            return resultTable;
        }

        public bool LuuThongTinNguoiDung()
        {
            // Tạo kết nối mới và bắt đầu một giao dịch
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlTransaction transaction = null;

            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();  // Bắt đầu giao dịch

                // Cập nhật bảng nguoidung
                foreach (DataRow row in dtNguoiDung.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        string insertQuery = "INSERT INTO nguoidung (userid, matkhau, hoten, ngaysinh, sdt, chucvu) " +
                                             "VALUES (@userid, @matkhau, @hoten, @ngaysinh, @sdt, @chucvu)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@matkhau", row["matkhau"]);
                            cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                            cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                            cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                            cmd.Parameters.AddWithValue("@chucvu", row["chucvu"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh INSERT
                        }
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                        string updateQuery = "UPDATE nguoidung SET matkhau = @matkhau, hoten = @hoten, ngaysinh = @ngaysinh, " +
                                             "sdt = @sdt, chucvu = @chucvu WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@matkhau", row["matkhau"]);
                            cmd.Parameters.AddWithValue("@hoten", row["hoten"]);
                            cmd.Parameters.AddWithValue("@ngaysinh", row["ngaysinh"]);
                            cmd.Parameters.AddWithValue("@sdt", row["sdt"]);
                            cmd.Parameters.AddWithValue("@chucvu", row["chucvu"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh UPDATE
                        }
                    }
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        string deleteQuery = "DELETE FROM nguoidung WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid", DataRowVersion.Original]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh DELETE
                        }
                    }
                }

                // Cập nhật bảng diachind
                foreach (DataRow row in dtDiaChiND.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        string insertQuery = "INSERT INTO diachind (userid, tinh, huyen_tp, sonha) " +
                                             "VALUES (@userid, @tinh, @huyen_tp, @sonha)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                            cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                            cmd.Parameters.AddWithValue("@sonha", row["sonha"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh INSERT
                        }
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                        string updateQuery = "UPDATE diachind SET tinh = @tinh, huyen_tp = @huyen_tp, sonha = @sonha " +
                                             "WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid"]);
                            cmd.Parameters.AddWithValue("@tinh", row["tinh"]);
                            cmd.Parameters.AddWithValue("@huyen_tp", row["huyen_tp"]);
                            cmd.Parameters.AddWithValue("@sonha", row["sonha"]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh UPDATE
                        }
                    }
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        string deleteQuery = "DELETE FROM diachind WHERE userid = @userid";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", row["userid", DataRowVersion.Original]);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh DELETE
                        }
                    }
                }

                // Commit giao dịch
                transaction.Commit();
                return true;  // Trả về giá trị true nếu lưu thành công
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, rollback giao dịch
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new Exception("Lỗi khi lưu thông tin vào cơ sở dữ liệu.", ex);
            }
            finally
            {
                // Đảm bảo đóng kết nối
                conn.Close();
            }
        }
    }
}
