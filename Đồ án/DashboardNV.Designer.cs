namespace Đồ_án
{
    partial class frmDashboardNV
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
            this.ptbMenu = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQLThanNhan = new System.Windows.Forms.Button();
            this.btnQLPhong = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnBaoTri = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnQLSinhVien = new System.Windows.Forms.Button();
            this.btnQLViPham = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lblQLKTX = new System.Windows.Forms.Label();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.timeMenu = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbMenu
            // 
            this.ptbMenu.Image = global::Đồ_án.Properties.Resources.List;
            this.ptbMenu.InitialImage = null;
            this.ptbMenu.Location = new System.Drawing.Point(321, 1);
            this.ptbMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbMenu.Name = "ptbMenu";
            this.ptbMenu.Size = new System.Drawing.Size(29, 30);
            this.ptbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMenu.TabIndex = 42;
            this.ptbMenu.TabStop = false;
            this.ptbMenu.Click += new System.EventHandler(this.ptbMenu_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.flpMenu);
            this.pnlMenu.Controls.Add(this.lblQLKTX);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(317, 543);
            this.pnlMenu.TabIndex = 41;
            // 
            // flpMenu
            // 
            this.flpMenu.AutoScroll = true;
            this.flpMenu.AutoScrollMinSize = new System.Drawing.Size(0, 450);
            this.flpMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.flpMenu.Controls.Add(this.btnQLThanNhan);
            this.flpMenu.Controls.Add(this.btnQLPhong);
            this.flpMenu.Controls.Add(this.btnThanhToan);
            this.flpMenu.Controls.Add(this.btnBaoTri);
            this.flpMenu.Controls.Add(this.btnThongKe);
            this.flpMenu.Controls.Add(this.btnQLSinhVien);
            this.flpMenu.Controls.Add(this.btnQLViPham);
            this.flpMenu.Controls.Add(this.btnDangXuat);
            this.flpMenu.Location = new System.Drawing.Point(3, 138);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(315, 400);
            this.flpMenu.TabIndex = 37;
            // 
            // btnQLThanNhan
            // 
            this.btnQLThanNhan.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLThanNhan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQLThanNhan.Location = new System.Drawing.Point(3, 2);
            this.btnQLThanNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLThanNhan.Name = "btnQLThanNhan";
            this.btnQLThanNhan.Size = new System.Drawing.Size(281, 53);
            this.btnQLThanNhan.TabIndex = 24;
            this.btnQLThanNhan.Text = "Quản lý thân nhân";
            this.btnQLThanNhan.UseVisualStyleBackColor = false;
            this.btnQLThanNhan.Click += new System.EventHandler(this.btnQLThanNhan_Click);
            // 
            // btnQLPhong
            // 
            this.btnQLPhong.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLPhong.Location = new System.Drawing.Point(3, 59);
            this.btnQLPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLPhong.Name = "btnQLPhong";
            this.btnQLPhong.Size = new System.Drawing.Size(281, 53);
            this.btnQLPhong.TabIndex = 25;
            this.btnQLPhong.Text = "Quản lý phòng";
            this.btnQLPhong.UseVisualStyleBackColor = false;
            this.btnQLPhong.Click += new System.EventHandler(this.btnQLPhong_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.LightBlue;
            this.btnThanhToan.Location = new System.Drawing.Point(3, 116);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(281, 53);
            this.btnThanhToan.TabIndex = 26;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnBaoTri
            // 
            this.btnBaoTri.BackColor = System.Drawing.Color.LightBlue;
            this.btnBaoTri.Location = new System.Drawing.Point(3, 173);
            this.btnBaoTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBaoTri.Name = "btnBaoTri";
            this.btnBaoTri.Size = new System.Drawing.Size(281, 53);
            this.btnBaoTri.TabIndex = 27;
            this.btnBaoTri.Text = "Bảo trì";
            this.btnBaoTri.UseVisualStyleBackColor = false;
            this.btnBaoTri.Click += new System.EventHandler(this.btnBaoTri_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.LightBlue;
            this.btnThongKe.Location = new System.Drawing.Point(3, 230);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(281, 53);
            this.btnThongKe.TabIndex = 28;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnQLSinhVien
            // 
            this.btnQLSinhVien.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLSinhVien.Location = new System.Drawing.Point(3, 287);
            this.btnQLSinhVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLSinhVien.Name = "btnQLSinhVien";
            this.btnQLSinhVien.Size = new System.Drawing.Size(281, 53);
            this.btnQLSinhVien.TabIndex = 31;
            this.btnQLSinhVien.Text = "Quản lý sinh viên";
            this.btnQLSinhVien.UseVisualStyleBackColor = false;
            this.btnQLSinhVien.Click += new System.EventHandler(this.btnQLSinhVien_Click);
            // 
            // btnQLViPham
            // 
            this.btnQLViPham.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLViPham.Location = new System.Drawing.Point(3, 344);
            this.btnQLViPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLViPham.Name = "btnQLViPham";
            this.btnQLViPham.Size = new System.Drawing.Size(281, 53);
            this.btnQLViPham.TabIndex = 32;
            this.btnQLViPham.Text = "Quản lý vi phạm";
            this.btnQLViPham.UseVisualStyleBackColor = false;
            this.btnQLViPham.Click += new System.EventHandler(this.btnQLViPham_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.LightBlue;
            this.btnDangXuat.Location = new System.Drawing.Point(3, 401);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(281, 54);
            this.btnDangXuat.TabIndex = 33;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblQLKTX
            // 
            this.lblQLKTX.BackColor = System.Drawing.Color.CadetBlue;
            this.lblQLKTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 34.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLKTX.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblQLKTX.Location = new System.Drawing.Point(3, 1);
            this.lblQLKTX.Name = "lblQLKTX";
            this.lblQLKTX.Padding = new System.Windows.Forms.Padding(29, 0, 0, 0);
            this.lblQLKTX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQLKTX.Size = new System.Drawing.Size(315, 137);
            this.lblQLKTX.TabIndex = 35;
            this.lblQLKTX.Text = " Quản lý\r\nký túc xá";
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.AutoSize = true;
            this.pnlHienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.pnlHienThi.Location = new System.Drawing.Point(31, 12);
            this.pnlHienThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(755, 526);
            this.pnlHienThi.TabIndex = 40;
            // 
            // timeMenu
            // 
            this.timeMenu.Interval = 10;
            this.timeMenu.Tick += new System.EventHandler(this.timeMenu_Tick);
            // 
            // frmDashboardNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 543);
            this.Controls.Add(this.ptbMenu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHienThi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDashboardNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardNV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardNV_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardNV_FormClosed);
            this.Load += new System.EventHandler(this.DashboardNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.flpMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Button btnQLThanNhan;
        private System.Windows.Forms.Button btnQLPhong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnBaoTri;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnQLSinhVien;
        private System.Windows.Forms.Button btnQLViPham;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblQLKTX;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.Timer timeMenu;
    }
}