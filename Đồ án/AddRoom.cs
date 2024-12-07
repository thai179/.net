using BLL;
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
        private PhongBLL phongBLL = new PhongBLL();
        public frmThemPhong()
        {
            InitializeComponent();
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

            string soPhong = txtSoPhong.Text;
            string tinhTrang = cbbTinhTrang.Text;
            string loaiPhong = cbbLoaiPhong.Text;
            int soNguoi;

            if (!int.TryParse(txtSoNguoi.Text, out soNguoi))
            {
                MessageBox.Show("Số lượng phải là sô nguyên dương", "Error");
                return;
            }
            if (soNguoi < 1 || soNguoi > 10)
            {
                MessageBox.Show("Số lượng tối đa không thể bé hơn 0 hoặc lớn hơn 10.");
                return;
            }

            string errorMessage;
            bool isAdded = phongBLL.AddPhong(soPhong, soNguoi, loaiPhong, tinhTrang, out errorMessage);

            if (isAdded)
            {
                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
