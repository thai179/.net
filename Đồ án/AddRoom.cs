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
    public partial class frmThemPhong : Form
    {
        private DataSet dsPhong;
        public frmThemPhong(DataSet dsPhong)
        {
            InitializeComponent();
            this.dsPhong = dsPhong;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSoNguoi.Text = "";
            txtSoPhong.Text = "";
            cbbLoaiPhong.SelectedIndex = 0;
            cbbTinhTrang.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ban co muon thoat form khong","thong bao",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sophong=txtSoPhong.Text;
            string tinhtrang=cbbTinhTrang.Text;
            string loaiphong=cbbLoaiPhong.Text;
            int songuoi;

            if(!int.TryParse(txtSoNguoi.Text, out songuoi))
            {
                MessageBox.Show("Số lượng phải là sô nguyên dương", "Error");
                return;
            }
            if (songuoi<1 || songuoi>10)
            {
                MessageBox.Show("Số lượng tối đa không thể bé hơn 0 hoặc lớn hơn 10.");
                return;
            }

            DataTable dataTable = dsPhong.Tables["phong"];
            DataRow[] row = dataTable.Select($"sophong = '{sophong}'");
            if (row.Length > 0 )
            {
                MessageBox.Show("Số phòng đã tồn tại.", "Lỗi");
                txtSoPhong.Focus();
                return;
            }
            DataRow newrow = dataTable.NewRow();
            newrow["sophong"] = sophong;
            newrow["sluongtoida"]= songuoi;
            newrow["loaiphong"] = loaiphong;
            newrow["tinhtrangphong"] = tinhtrang;

            dataTable.Rows.Add(newrow);
            MessageBox.Show("Phòng đã được thêm vào DataSet thành công.", "Thông báo");
        }

    }
}
