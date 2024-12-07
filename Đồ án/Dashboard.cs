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
    public partial class frmDashboard : Form
    {
        private bool logoutFlag=false;

        private frmQLTTLienLac qlThanNhan;
        private frmQLPhong qlPhong;
        private frmThanhToan thanhToan;
        private frmBaoTri baoTri;
        private frmThongKe thongKe;
        private frmPhanHoi phanHoi;
        private frmQLNguoiDung qlNguoiDung;
        private frmQLSV qlSV;
        private frmViPham viPham;
        public frmDashboard()
        {
            InitializeComponent();
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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            qlThanNhan = new frmQLTTLienLac();
            qlPhong = new frmQLPhong();
            thanhToan = new frmThanhToan();
            baoTri = new frmBaoTri();
            thongKe = new frmThongKe();
            phanHoi = new frmPhanHoi();
            qlNguoiDung = new frmQLNguoiDung();
            qlSV = new frmQLSV();
            viPham = new frmViPham();
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

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(phanHoi);
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
            SwitchToForm(qlNguoiDung);
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

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logoutFlag)
                return;
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (logoutFlag)
                return ;
            Application.Exit();
        }

        bool isCollapsed=false;
        private void ptbMenu_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
        }

        private void timeMenu_Tick(object sender, EventArgs e)
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
    }
}
