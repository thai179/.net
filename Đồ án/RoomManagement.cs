using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmQLPhong : Form
    {
        public frmQLPhong()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemPhong themPhong = new frmThemPhong();
            themPhong.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmSuaPhong suaPhong = new frmSuaPhong();
            suaPhong.ShowDialog();
        }

        private void frmQLPhong_Load(object sender, EventArgs e)
        {
            string query = "select * from phong";
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query,conn);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataTable.Columns["sophong"].ColumnName = "Số phòng";
                dataTable.Columns["sluongtoida"].ColumnName = "Số lượng tối đa";
                dataTable.Columns["sluongsv"].ColumnName = "Số lượng sinh viên";
                dataTable.Columns["loaiphong"].ColumnName = "Loại phòng";
                dataTable.Columns["tinhtrangphong"].ColumnName = "Tình Trạng";
                dgvHienThi.DataSource = dataTable;
            }
        }
    }
}
