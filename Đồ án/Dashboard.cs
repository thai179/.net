﻿using System;
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
        private frmQLPhong qlPhong;
        private frmThanhToan thanhToan;
        private frmBaoTri baoTri;
        private frmThongKe thongKe;
        private frmPhanHoi phanHoi;
        private frmQLNguoiDung qlNguoiDung;
        private frmQLSV qlSV;
        private frmViPham viPham;
        public frmDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ban co muon dang xuat khong", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string chucvu = "";
            using (SqlConnection connection = ConnectionManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT chucvu FROM nguoidung WHERE userid = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                object result = command.ExecuteScalar();
                chucvu = (string)result;
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
            qlPhong = new frmQLPhong();
            thanhToan = new frmThanhToan();
            baoTri = new frmBaoTri();
            thongKe = new frmThongKe();
            phanHoi = new frmPhanHoi();
            qlNguoiDung = new frmQLNguoiDung();
            qlSV = new frmQLSV();
            viPham = new frmViPham();
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            SwitchToForm(qlPhong);
        }

        

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            SwitchToForm(thanhToan);
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            SwitchToForm(baoTri);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            SwitchToForm(thongKe);
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            SwitchToForm(phanHoi);
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {
            SwitchToForm(qlNguoiDung);
        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            SwitchToForm(qlSV);
        }

        private void btnQLViPham_Click(object sender, EventArgs e)
        {
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
            //DialogResult result = MessageBox.Show("Bạn có chắc là muốn thoát chương trình không?","Thông Báo",MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes) 
                Application.Exit();
        }
    }
}
