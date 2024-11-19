namespace Đồ_án
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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.btnQLViPham = new System.Windows.Forms.Button();
            this.btnQLSinhVien = new System.Windows.Forms.Button();
            this.btnQLNguoiDung = new System.Windows.Forms.Button();
            this.btnPhanHoi = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnBaoTri = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnQLPhong = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(987, 26);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(135, 54);
            this.btnDangXuat.TabIndex = 33;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 69);
            this.label1.TabIndex = 35;
            this.label1.Text = "Quản lý ký túc xá";
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.Location = new System.Drawing.Point(367, 135);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(755, 525);
            this.pnlHienThi.TabIndex = 34;
            // 
            // btnQLViPham
            // 
            this.btnQLViPham.Location = new System.Drawing.Point(39, 607);
            this.btnQLViPham.Name = "btnQLViPham";
            this.btnQLViPham.Size = new System.Drawing.Size(281, 53);
            this.btnQLViPham.TabIndex = 32;
            this.btnQLViPham.Text = "Quản lý vi phạm";
            this.btnQLViPham.UseVisualStyleBackColor = true;
            this.btnQLViPham.Click += new System.EventHandler(this.btnQLViPham_Click);
            // 
            // btnQLSinhVien
            // 
            this.btnQLSinhVien.Location = new System.Drawing.Point(39, 548);
            this.btnQLSinhVien.Name = "btnQLSinhVien";
            this.btnQLSinhVien.Size = new System.Drawing.Size(281, 53);
            this.btnQLSinhVien.TabIndex = 31;
            this.btnQLSinhVien.Text = "Quản lý sinh viên";
            this.btnQLSinhVien.UseVisualStyleBackColor = true;
            this.btnQLSinhVien.Click += new System.EventHandler(this.btnQLSinhVien_Click);
            // 
            // btnQLNguoiDung
            // 
            this.btnQLNguoiDung.Location = new System.Drawing.Point(39, 489);
            this.btnQLNguoiDung.Name = "btnQLNguoiDung";
            this.btnQLNguoiDung.Size = new System.Drawing.Size(281, 53);
            this.btnQLNguoiDung.TabIndex = 30;
            this.btnQLNguoiDung.Text = "Quản lý người dùng";
            this.btnQLNguoiDung.UseVisualStyleBackColor = true;
            this.btnQLNguoiDung.Click += new System.EventHandler(this.btnQLNguoiDung_Click);
            // 
            // btnPhanHoi
            // 
            this.btnPhanHoi.Location = new System.Drawing.Point(39, 430);
            this.btnPhanHoi.Name = "btnPhanHoi";
            this.btnPhanHoi.Size = new System.Drawing.Size(281, 53);
            this.btnPhanHoi.TabIndex = 29;
            this.btnPhanHoi.Text = "Phản hồi";
            this.btnPhanHoi.UseVisualStyleBackColor = true;
            this.btnPhanHoi.Click += new System.EventHandler(this.btnPhanHoi_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(39, 371);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(281, 53);
            this.btnThongKe.TabIndex = 28;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnBaoTri
            // 
            this.btnBaoTri.Location = new System.Drawing.Point(39, 312);
            this.btnBaoTri.Name = "btnBaoTri";
            this.btnBaoTri.Size = new System.Drawing.Size(281, 53);
            this.btnBaoTri.TabIndex = 27;
            this.btnBaoTri.Text = "Bảo trì";
            this.btnBaoTri.UseVisualStyleBackColor = true;
            this.btnBaoTri.Click += new System.EventHandler(this.btnBaoTri_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(39, 253);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(281, 53);
            this.btnThanhToan.TabIndex = 26;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnQLPhong
            // 
            this.btnQLPhong.Location = new System.Drawing.Point(39, 194);
            this.btnQLPhong.Name = "btnQLPhong";
            this.btnQLPhong.Size = new System.Drawing.Size(281, 53);
            this.btnQLPhong.TabIndex = 25;
            this.btnQLPhong.Text = "Quản lý phòng";
            this.btnQLPhong.UseVisualStyleBackColor = true;
            this.btnQLPhong.Click += new System.EventHandler(this.btnQLPhong_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 53);
            this.button1.TabIndex = 24;
            this.button1.Text = "Đăng ký ký túc xá";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 686);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHienThi);
            this.Controls.Add(this.btnQLViPham);
            this.Controls.Add(this.btnQLSinhVien);
            this.Controls.Add(this.btnQLNguoiDung);
            this.Controls.Add(this.btnPhanHoi);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnBaoTri);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnQLPhong);
            this.Controls.Add(this.button1);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.Button btnQLViPham;
        private System.Windows.Forms.Button btnQLSinhVien;
        private System.Windows.Forms.Button btnQLNguoiDung;
        private System.Windows.Forms.Button btnPhanHoi;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnBaoTri;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnQLPhong;
        private System.Windows.Forms.Button button1;
    }
}