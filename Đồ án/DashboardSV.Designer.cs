namespace Đồ_án
{
    partial class frmDashboardSV
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
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnBaoTri = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnPhanHoi = new System.Windows.Forms.Button();
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
            this.ptbMenu.Location = new System.Drawing.Point(313, 1);
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
            this.pnlMenu.Size = new System.Drawing.Size(309, 543);
            this.pnlMenu.TabIndex = 41;
            // 
            // flpMenu
            // 
            this.flpMenu.AutoScroll = true;
            this.flpMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.flpMenu.Controls.Add(this.btnQLThanNhan);
            this.flpMenu.Controls.Add(this.btnThanhToan);
            this.flpMenu.Controls.Add(this.btnBaoTri);
            this.flpMenu.Controls.Add(this.btnThongKe);
            this.flpMenu.Controls.Add(this.btnPhanHoi);
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
            this.btnQLThanNhan.Size = new System.Drawing.Size(301, 62);
            this.btnQLThanNhan.TabIndex = 24;
            this.btnQLThanNhan.Text = "Quản lý thân nhân";
            this.btnQLThanNhan.UseVisualStyleBackColor = false;
            this.btnQLThanNhan.Click += new System.EventHandler(this.btnQLThanNhan_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.LightBlue;
            this.btnThanhToan.Location = new System.Drawing.Point(3, 68);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(301, 62);
            this.btnThanhToan.TabIndex = 26;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnBaoTri
            // 
            this.btnBaoTri.BackColor = System.Drawing.Color.LightBlue;
            this.btnBaoTri.Location = new System.Drawing.Point(3, 134);
            this.btnBaoTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBaoTri.Name = "btnBaoTri";
            this.btnBaoTri.Size = new System.Drawing.Size(301, 62);
            this.btnBaoTri.TabIndex = 27;
            this.btnBaoTri.Text = "Bảo trì";
            this.btnBaoTri.UseVisualStyleBackColor = false;
            this.btnBaoTri.Click += new System.EventHandler(this.btnBaoTri_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.LightBlue;
            this.btnThongKe.Location = new System.Drawing.Point(3, 200);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(301, 62);
            this.btnThongKe.TabIndex = 28;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnPhanHoi
            // 
            this.btnPhanHoi.BackColor = System.Drawing.Color.LightBlue;
            this.btnPhanHoi.Location = new System.Drawing.Point(3, 266);
            this.btnPhanHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhanHoi.Name = "btnPhanHoi";
            this.btnPhanHoi.Size = new System.Drawing.Size(301, 62);
            this.btnPhanHoi.TabIndex = 29;
            this.btnPhanHoi.Text = "Phản hồi";
            this.btnPhanHoi.UseVisualStyleBackColor = false;
            this.btnPhanHoi.Click += new System.EventHandler(this.btnPhanHoi_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.LightBlue;
            this.btnDangXuat.Location = new System.Drawing.Point(3, 332);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(301, 62);
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
            // frmDashboardSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(797, 543);
            this.Controls.Add(this.ptbMenu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHienThi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDashboardSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardSV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboardSV_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDashboardSV_FormClosed);
            this.Load += new System.EventHandler(this.frmDashboardSV_Load);
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
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnBaoTri;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnPhanHoi;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblQLKTX;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.Timer timeMenu;
    }
}