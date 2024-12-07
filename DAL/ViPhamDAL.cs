using Đồ_án;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViPhamDAL
    {
        private DataSet dsViPham = new DataSet();
        public void LoadViPhamData()
        {
            string query = "SELECT * FROM thongtinvipham";
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());
            adapter.Fill(dsViPham, "ViPham");
        }

        public DataTable GetSinhVienByMSSV(string mssv)
        {
            string query = "SELECT hoten, sophong FROM sinhvien WHERE masv = @mssv";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void AddViPham(string mssv, string hoTen, string soPhong, string moTaViPham, string hinhThucXuLy)
        {
            DataTable viPhamTable = dsViPham.Tables["ViPham"];
            DataRow newRow = viPhamTable.NewRow();
            newRow["masv"] = mssv;
            newRow["hoten"] = hoTen;
            newRow["sophong"] = soPhong;
            newRow["ndvp"] = moTaViPham;
            newRow["htxuly"] = hinhThucXuLy;
            viPhamTable.Rows.Add(newRow);
        }

        public void SaveChanges()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM thongtinvipham", conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dsViPham, "ViPham");
        }
        public void UndoChanges()
        {
            dsViPham.RejectChanges();
        }
    }
}
