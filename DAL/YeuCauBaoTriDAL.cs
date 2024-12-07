using Đồ_án;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class YeuCauBaoTriDAL
    {
        public void GuiYeuCau(YeuCauBaoTriDTO yeuCau)
        {
            string query = "INSERT INTO yeucaubaotri (sophong, ndyc, douutien) VALUES (@sophong, @ndyc, @douutien)";

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sophong", yeuCau.SoPhong);
                cmd.Parameters.AddWithValue("@ndyc", yeuCau.MoTaVanDe);
                cmd.Parameters.AddWithValue("@douutien", yeuCau.DoUuTien);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Đã có lỗi xảy ra: " + ex.Message);
                }
            }
        }
    }
}
