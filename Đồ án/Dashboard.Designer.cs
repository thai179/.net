﻿namespace Đồ_án
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblQLKTX = new System.Windows.Forms.Label();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.ptbMenu = new System.Windows.Forms.PictureBox();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnQLViPham = new System.Windows.Forms.Button();
            this.btnQLSinhVien = new System.Windows.Forms.Button();
            this.btnQLNguoiDung = new System.Windows.Forms.Button();
            this.btnPhanHoi = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnBaoTri = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnQLPhong = new System.Windows.Forms.Button();
            this.btnQLThanNhan = new System.Windows.Forms.Button();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.timeMenu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).BeginInit();
            this.flpMenu.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQLKTX
            // 
            this.lblQLKTX.BackColor = System.Drawing.Color.CadetBlue;
            this.lblQLKTX.Font = new System.Drawing.Font("Times New Roman", 34.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLKTX.ForeColor = System.Drawing.Color.White;
            this.lblQLKTX.Location = new System.Drawing.Point(3, 1);
            this.lblQLKTX.Name = "lblQLKTX";
            this.lblQLKTX.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblQLKTX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQLKTX.Size = new System.Drawing.Size(315, 137);
            this.lblQLKTX.TabIndex = 35;
            this.lblQLKTX.Text = " Quản lý\r\nký túc xá";
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.AutoSize = true;
            this.pnlHienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.pnlHienThi.Location = new System.Drawing.Point(19, 12);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(755, 525);
            this.pnlHienThi.TabIndex = 34;
            // 
            // ptbMenu
            // 
            this.ptbMenu.Image = global::Đồ_án.Properties.Resources.List;
            this.ptbMenu.InitialImage = null;
            this.ptbMenu.Location = new System.Drawing.Point(319, 1);
            this.ptbMenu.Name = "ptbMenu";
            this.ptbMenu.Size = new System.Drawing.Size(36, 32);
            this.ptbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMenu.TabIndex = 39;
            this.ptbMenu.TabStop = false;
            this.ptbMenu.Click += new System.EventHandler(this.ptbMenu_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.LightBlue;
            this.btnDangXuat.Location = new System.Drawing.Point(3, 534);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(281, 54);
            this.btnDangXuat.TabIndex = 33;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnQLViPham
            // 
            this.btnQLViPham.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLViPham.Location = new System.Drawing.Point(3, 475);
            this.btnQLViPham.Name = "btnQLViPham";
            this.btnQLViPham.Size = new System.Drawing.Size(281, 53);
            this.btnQLViPham.TabIndex = 32;
            this.btnQLViPham.Text = "Quản lý vi phạm";
            this.btnQLViPham.UseVisualStyleBackColor = false;
            this.btnQLViPham.Click += new System.EventHandler(this.btnQLViPham_Click);
            // 
            // btnQLSinhVien
            // 
            this.btnQLSinhVien.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLSinhVien.Location = new System.Drawing.Point(3, 416);
            this.btnQLSinhVien.Name = "btnQLSinhVien";
            this.btnQLSinhVien.Size = new System.Drawing.Size(281, 53);
            this.btnQLSinhVien.TabIndex = 31;
            this.btnQLSinhVien.Text = "Quản lý sinh viên";
            this.btnQLSinhVien.UseVisualStyleBackColor = false;
            this.btnQLSinhVien.Click += new System.EventHandler(this.btnQLSinhVien_Click);
            // 
            // btnQLNguoiDung
            // 
            this.btnQLNguoiDung.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLNguoiDung.Location = new System.Drawing.Point(3, 357);
            this.btnQLNguoiDung.Name = "btnQLNguoiDung";
            this.btnQLNguoiDung.Size = new System.Drawing.Size(281, 53);
            this.btnQLNguoiDung.TabIndex = 30;
            this.btnQLNguoiDung.Text = "Quản lý người dùng";
            this.btnQLNguoiDung.UseVisualStyleBackColor = false;
            this.btnQLNguoiDung.Click += new System.EventHandler(this.btnQLNguoiDung_Click);
            // 
            // btnPhanHoi
            // 
            this.btnPhanHoi.BackColor = System.Drawing.Color.LightBlue;
            this.btnPhanHoi.Location = new System.Drawing.Point(3, 298);
            this.btnPhanHoi.Name = "btnPhanHoi";
            this.btnPhanHoi.Size = new System.Drawing.Size(281, 53);
            this.btnPhanHoi.TabIndex = 29;
            this.btnPhanHoi.Text = "Phản hồi";
            this.btnPhanHoi.UseVisualStyleBackColor = false;
            this.btnPhanHoi.Click += new System.EventHandler(this.btnPhanHoi_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.LightBlue;
            this.btnThongKe.Location = new System.Drawing.Point(3, 239);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(281, 53);
            this.btnThongKe.TabIndex = 28;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnBaoTri
            // 
            this.btnBaoTri.BackColor = System.Drawing.Color.LightBlue;
            this.btnBaoTri.Location = new System.Drawing.Point(3, 180);
            this.btnBaoTri.Name = "btnBaoTri";
            this.btnBaoTri.Size = new System.Drawing.Size(281, 53);
            this.btnBaoTri.TabIndex = 27;
            this.btnBaoTri.Text = "Bảo trì";
            this.btnBaoTri.UseVisualStyleBackColor = false;
            this.btnBaoTri.Click += new System.EventHandler(this.btnBaoTri_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.LightBlue;
            this.btnThanhToan.Location = new System.Drawing.Point(3, 121);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(281, 53);
            this.btnThanhToan.TabIndex = 26;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnQLPhong
            // 
            this.btnQLPhong.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLPhong.Location = new System.Drawing.Point(3, 62);
            this.btnQLPhong.Name = "btnQLPhong";
            this.btnQLPhong.Size = new System.Drawing.Size(281, 53);
            this.btnQLPhong.TabIndex = 25;
            this.btnQLPhong.Text = "Quản lý phòng";
            this.btnQLPhong.UseVisualStyleBackColor = false;
            this.btnQLPhong.Click += new System.EventHandler(this.btnQLPhong_Click);
            // 
            // btnQLThanNhan
            // 
            this.btnQLThanNhan.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLThanNhan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQLThanNhan.Location = new System.Drawing.Point(3, 3);
            this.btnQLThanNhan.Name = "btnQLThanNhan";
            this.btnQLThanNhan.Size = new System.Drawing.Size(281, 53);
            this.btnQLThanNhan.TabIndex = 24;
            this.btnQLThanNhan.Text = "Quản lý thân nhân";
            this.btnQLThanNhan.UseVisualStyleBackColor = false;
            this.btnQLThanNhan.Click += new System.EventHandler(this.btnQLThanNhan_Click);
            // 
            // flpMenu
            // 
            this.flpMenu.AutoScroll = true;
            this.flpMenu.AutoScrollMinSize = new System.Drawing.Size(0, 450);
            this.flpMenu.BackColor = System.Drawing.Color.CadetBlue;
            this.flpMenu.Controls.Add(this.btnQLThanNhan);
            this.flpMenu.Controls.Add(this.btnQLPhong);
            this.flpMenu.Controls.Add(this.btnThanhToan);
            this.flpMenu.Controls.Add(this.btnBaoTri);
            this.flpMenu.Controls.Add(this.btnThongKe);
            this.flpMenu.Controls.Add(this.btnPhanHoi);
            this.flpMenu.Controls.Add(this.btnQLNguoiDung);
            this.flpMenu.Controls.Add(this.btnQLSinhVien);
            this.flpMenu.Controls.Add(this.btnQLViPham);
            this.flpMenu.Controls.Add(this.btnDangXuat);
            this.flpMenu.Location = new System.Drawing.Point(3, 138);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(315, 400);
            this.flpMenu.TabIndex = 37;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.flpMenu);
            this.pnlMenu.Controls.Add(this.lblQLKTX);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(318, 543);
            this.pnlMenu.TabIndex = 38;
            // 
            // timeMenu
            // 
            this.timeMenu.Interval = 10;
            this.timeMenu.Tick += new System.EventHandler(this.timeMenu_Tick);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(797, 543);
            this.Controls.Add(this.ptbMenu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHienThi);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).EndInit();
            this.flpMenu.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblQLKTX;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.Button btnBaoTri;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnPhanHoi;
        private System.Windows.Forms.Button btnQLPhong;
        private System.Windows.Forms.Button btnQLNguoiDung;
        private System.Windows.Forms.Button btnQLSinhVien;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnQLViPham;
        private System.Windows.Forms.Button btnQLThanNhan;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox ptbMenu;
        private System.Windows.Forms.Timer timeMenu;
    }
}