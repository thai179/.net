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
        private string username;
        private frmQLTTLienLac qlThanNhan;
        private frmQLPhong qlPhong;
        private frmThanhToan thanhToan;
        private frmBaoTri baoTri;
        private frmThongKe thongKe;
        private frmPhanHoi phanHoi;
        private frmQLNguoiDung qlNguoiDung;
        private frmQLSV qlSV;
        private frmViPham viPham;
        private DataSet dsNguoiDung;
        public frmDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dsNguoiDung = new DataSet();
            string chucvu = "";
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT chucvu FROM nguoidung WHERE userid = @Username";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Username", username);

                adapter.Fill(dsNguoiDung, "nguoidung");

                if (dsNguoiDung.Tables["nguoidung"].Rows.Count > 0)
                {
                    chucvu = dsNguoiDung.Tables["nguoidung"].Rows[0]["chucvu"].ToString();
                }
                if (chucvu == "Sinh Vien")
                {
                    btnQLNguoiDung.Enabled = false;
                    btnQLPhong.Enabled = false;
                    btnQLViPham.Enabled = false;
                    btnQLSinhVien.Enabled = false;
                }
                else if (chucvu == "Nhan Vien")
                {
                    btnQLNguoiDung.Enabled=false;
                    btnPhanHoi.Enabled = false;
                }
            }
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
            timer1.Start();
            SwitchToForm(qlThanNhan);
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(qlPhong);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(thanhToan);
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(baoTri);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(thongKe);
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(phanHoi);
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(qlNguoiDung);
        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwitchToForm(qlSV);
        }

        private void btnQLViPham_Click(object sender, EventArgs e)
        {
            timer1.Start();
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
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        bool isCollapsed=false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Width += 10;
                if (panel1.Width >= 318)
                {
                    timer1.Stop();
                    panel1.Width = 235;
                    isCollapsed = false;
                }
            }
            else
            {
                panel1.Width -= 10;
                if (panel1.Width <= 0 )
                {
                    timer1.Stop();
                    panel1.Width= 0;
                    isCollapsed = true;
                }
            }
        }
    }
}
