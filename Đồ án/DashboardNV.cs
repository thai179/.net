using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{

    public partial class frmDashboardNV : Form
    {
        private bool logoutFlag =false;

        private frmQLTTLienLac qlThanNhan;
        private frmQLPhong qlPhong;
        private frmThanhToan thanhToan;
        private frmBaoTri baoTri;
        private frmThongKe thongKe;
        private frmQLSV qlSV;
        private frmViPham viPham;
        public frmDashboardNV()
        {
            InitializeComponent();
        }

        private void SwitchToForm(Form targetForm)
        {
            foreach (Control ctrl in pnlHienThi.Controls)
            {
                ctrl.Hide();  // Ẩn tất cả các form hiện tại
            }
            targetForm.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Add(targetForm);
            targetForm.Show();  // Hiển thị form mới
        }

        bool isCollapsed = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlMenu.Width += 10;
                ptbMenu.Location = new Point(ptbMenu.Location.X + 9, ptbMenu.Location.Y);
                if (pnlMenu.Width >= 318)
                {
                    timeMenu.Stop();
                    pnlMenu.Width = 235;
                    ptbMenu.Location = new Point(236, ptbMenu.Location.Y);
                    isCollapsed = false;
                }
            }
            else
            {
                ptbMenu.Location = new Point(ptbMenu.Location.X - 10, ptbMenu.Location.Y);
                pnlMenu.Width -= 10;
                if (pnlMenu.Width <= 0)
                {
                    timeMenu.Stop();
                    pnlMenu.Width = 0;
                    ptbMenu.Location = new Point(0, ptbMenu.Location.Y);
                    isCollapsed = true;
                }
            }
        }

        private void ptbMenu_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
        }

        private void btnQLThanNhan_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(qlThanNhan);
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(qlPhong);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(thanhToan);
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(baoTri);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(thongKe);
        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(qlSV);
        }

        private void btnQLViPham_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(viPham);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.logoutFlag = true;
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDashboardNV_Load(object sender, EventArgs e)
        {
            qlThanNhan = new frmQLTTLienLac();
            qlPhong = new frmQLPhong();
            thanhToan = new frmThanhToan();
            baoTri = new frmBaoTri();
            thongKe = new frmThongKe();
            qlSV = new frmQLSV();
            viPham = new frmViPham();
        }

        private void frmDashboardNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logoutFlag)
                return;
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void frmDashboardNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (logoutFlag)
                return;
            Application.Exit();
        }
    }
}
