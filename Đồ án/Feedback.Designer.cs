namespace Đồ_án
{
    partial class frmPhanHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanHoi));
            this.lblPhanHoiVaDanhGia = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDanhGia = new System.Windows.Forms.Label();
            this.lblYKiem = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ptbSao1 = new System.Windows.Forms.PictureBox();
            this.txtYKien = new System.Windows.Forms.TextBox();
            this.btnGuiPhanHoi = new System.Windows.Forms.Button();
            this.frmHuy = new System.Windows.Forms.Button();
            this.ptbRong1 = new System.Windows.Forms.PictureBox();
            this.ptbRong2 = new System.Windows.Forms.PictureBox();
            this.ptbSao2 = new System.Windows.Forms.PictureBox();
            this.ptbRong3 = new System.Windows.Forms.PictureBox();
            this.ptbSao3 = new System.Windows.Forms.PictureBox();
            this.ptbRong4 = new System.Windows.Forms.PictureBox();
            this.ptbSao4 = new System.Windows.Forms.PictureBox();
            this.ptbRong5 = new System.Windows.Forms.PictureBox();
            this.ptbSao5 = new System.Windows.Forms.PictureBox();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhanHoiVaDanhGia
            // 
            this.lblPhanHoiVaDanhGia.AutoSize = true;
            this.lblPhanHoiVaDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanHoiVaDanhGia.Location = new System.Drawing.Point(156, 29);
            this.lblPhanHoiVaDanhGia.Name = "lblPhanHoiVaDanhGia";
            this.lblPhanHoiVaDanhGia.Size = new System.Drawing.Size(400, 46);
            this.lblPhanHoiVaDanhGia.TabIndex = 1;
            this.lblPhanHoiVaDanhGia.Text = "Phản hồi và Đánh giá";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(65, 162);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(69, 20);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(65, 113);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(61, 20);
            this.lblMSSV.TabIndex = 3;
            this.lblMSSV.Text = "MSSV:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(65, 213);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "SĐT:";
            // 
            // lblDanhGia
            // 
            this.lblDanhGia.AutoSize = true;
            this.lblDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhGia.Location = new System.Drawing.Point(65, 267);
            this.lblDanhGia.Name = "lblDanhGia";
            this.lblDanhGia.Size = new System.Drawing.Size(80, 20);
            this.lblDanhGia.TabIndex = 5;
            this.lblDanhGia.Text = "Đánh giá:";
            // 
            // lblYKiem
            // 
            this.lblYKiem.AutoSize = true;
            this.lblYKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYKiem.Location = new System.Drawing.Point(65, 315);
            this.lblYKiem.Name = "lblYKiem";
            this.lblYKiem.Size = new System.Drawing.Size(59, 20);
            this.lblYKiem.TabIndex = 6;
            this.lblYKiem.Text = "Ý kiến:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(175, 160);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(485, 22);
            this.txtHoTen.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(175, 211);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(485, 22);
            this.txtSDT.TabIndex = 8;
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(175, 113);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(485, 22);
            this.txtMSSV.TabIndex = 9;
            this.txtMSSV.Leave += new System.EventHandler(this.txtMSSV_Leave);
            // 
            // ptbSao1
            // 
            this.ptbSao1.Image = ((System.Drawing.Image)(resources.GetObject("ptbSao1.Image")));
            this.ptbSao1.Location = new System.Drawing.Point(189, 253);
            this.ptbSao1.Name = "ptbSao1";
            this.ptbSao1.Size = new System.Drawing.Size(45, 45);
            this.ptbSao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSao1.TabIndex = 10;
            this.ptbSao1.TabStop = false;
            this.ptbSao1.Click += new System.EventHandler(this.ptbSao1_Click);
            // 
            // txtYKien
            // 
            this.txtYKien.Location = new System.Drawing.Point(175, 315);
            this.txtYKien.Multiline = true;
            this.txtYKien.Name = "txtYKien";
            this.txtYKien.Size = new System.Drawing.Size(485, 113);
            this.txtYKien.TabIndex = 15;
            // 
            // btnGuiPhanHoi
            // 
            this.btnGuiPhanHoi.Location = new System.Drawing.Point(120, 444);
            this.btnGuiPhanHoi.Name = "btnGuiPhanHoi";
            this.btnGuiPhanHoi.Size = new System.Drawing.Size(138, 51);
            this.btnGuiPhanHoi.TabIndex = 16;
            this.btnGuiPhanHoi.Text = "Gửi phản hồi";
            this.btnGuiPhanHoi.UseVisualStyleBackColor = true;
            this.btnGuiPhanHoi.Click += new System.EventHandler(this.btnGuiPhanHoi_Click);
            // 
            // frmHuy
            // 
            this.frmHuy.Location = new System.Drawing.Point(496, 444);
            this.frmHuy.Name = "frmHuy";
            this.frmHuy.Size = new System.Drawing.Size(138, 51);
            this.frmHuy.TabIndex = 17;
            this.frmHuy.Text = "Hủy";
            this.frmHuy.UseVisualStyleBackColor = true;
            this.frmHuy.Click += new System.EventHandler(this.frmHuy_Click);
            // 
            // ptbRong1
            // 
            this.ptbRong1.Image = ((System.Drawing.Image)(resources.GetObject("ptbRong1.Image")));
            this.ptbRong1.Location = new System.Drawing.Point(189, 253);
            this.ptbRong1.Name = "ptbRong1";
            this.ptbRong1.Size = new System.Drawing.Size(45, 45);
            this.ptbRong1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbRong1.TabIndex = 18;
            this.ptbRong1.TabStop = false;
            this.ptbRong1.Click += new System.EventHandler(this.ptbRong1_Click);
            // 
            // ptbRong2
            // 
            this.ptbRong2.Image = ((System.Drawing.Image)(resources.GetObject("ptbRong2.Image")));
            this.ptbRong2.Location = new System.Drawing.Point(275, 253);
            this.ptbRong2.Name = "ptbRong2";
            this.ptbRong2.Size = new System.Drawing.Size(45, 45);
            this.ptbRong2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbRong2.TabIndex = 20;
            this.ptbRong2.TabStop = false;
            this.ptbRong2.Click += new System.EventHandler(this.ptbRong2_Click);
            // 
            // ptbSao2
            // 
            this.ptbSao2.Image = ((System.Drawing.Image)(resources.GetObject("ptbSao2.Image")));
            this.ptbSao2.Location = new System.Drawing.Point(275, 253);
            this.ptbSao2.Name = "ptbSao2";
            this.ptbSao2.Size = new System.Drawing.Size(45, 45);
            this.ptbSao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSao2.TabIndex = 19;
            this.ptbSao2.TabStop = false;
            this.ptbSao2.Click += new System.EventHandler(this.ptbSao2_Click);
            // 
            // ptbRong3
            // 
            this.ptbRong3.Image = ((System.Drawing.Image)(resources.GetObject("ptbRong3.Image")));
            this.ptbRong3.Location = new System.Drawing.Point(364, 253);
            this.ptbRong3.Name = "ptbRong3";
            this.ptbRong3.Size = new System.Drawing.Size(45, 45);
            this.ptbRong3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbRong3.TabIndex = 22;
            this.ptbRong3.TabStop = false;
            this.ptbRong3.Click += new System.EventHandler(this.ptbRong3_Click);
            // 
            // ptbSao3
            // 
            this.ptbSao3.Image = ((System.Drawing.Image)(resources.GetObject("ptbSao3.Image")));
            this.ptbSao3.Location = new System.Drawing.Point(364, 253);
            this.ptbSao3.Name = "ptbSao3";
            this.ptbSao3.Size = new System.Drawing.Size(45, 45);
            this.ptbSao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSao3.TabIndex = 21;
            this.ptbSao3.TabStop = false;
            this.ptbSao3.Click += new System.EventHandler(this.ptbSao3_Click);
            // 
            // ptbRong4
            // 
            this.ptbRong4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ptbRong4.Image = ((System.Drawing.Image)(resources.GetObject("ptbRong4.Image")));
            this.ptbRong4.Location = new System.Drawing.Point(452, 253);
            this.ptbRong4.Name = "ptbRong4";
            this.ptbRong4.Size = new System.Drawing.Size(45, 45);
            this.ptbRong4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbRong4.TabIndex = 24;
            this.ptbRong4.TabStop = false;
            this.ptbRong4.Click += new System.EventHandler(this.ptbRong4_Click);
            // 
            // ptbSao4
            // 
            this.ptbSao4.Image = ((System.Drawing.Image)(resources.GetObject("ptbSao4.Image")));
            this.ptbSao4.Location = new System.Drawing.Point(452, 253);
            this.ptbSao4.Name = "ptbSao4";
            this.ptbSao4.Size = new System.Drawing.Size(45, 45);
            this.ptbSao4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSao4.TabIndex = 23;
            this.ptbSao4.TabStop = false;
            this.ptbSao4.Click += new System.EventHandler(this.ptbSao4_Click);
            // 
            // ptbRong5
            // 
            this.ptbRong5.Image = ((System.Drawing.Image)(resources.GetObject("ptbRong5.Image")));
            this.ptbRong5.Location = new System.Drawing.Point(537, 253);
            this.ptbRong5.Name = "ptbRong5";
            this.ptbRong5.Size = new System.Drawing.Size(45, 45);
            this.ptbRong5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbRong5.TabIndex = 26;
            this.ptbRong5.TabStop = false;
            this.ptbRong5.Click += new System.EventHandler(this.ptbRong5_Click);
            // 
            // ptbSao5
            // 
            this.ptbSao5.Image = ((System.Drawing.Image)(resources.GetObject("ptbSao5.Image")));
            this.ptbSao5.Location = new System.Drawing.Point(537, 253);
            this.ptbSao5.Name = "ptbSao5";
            this.ptbSao5.Size = new System.Drawing.Size(45, 45);
            this.ptbSao5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSao5.TabIndex = 25;
            this.ptbSao5.TabStop = false;
            this.ptbSao5.Click += new System.EventHandler(this.ptbSao5_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(308, 444);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(138, 51);
            this.btnLuu.TabIndex = 27;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmPhanHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.ptbRong5);
            this.Controls.Add(this.ptbSao5);
            this.Controls.Add(this.ptbRong4);
            this.Controls.Add(this.ptbSao4);
            this.Controls.Add(this.ptbRong3);
            this.Controls.Add(this.ptbSao3);
            this.Controls.Add(this.ptbRong2);
            this.Controls.Add(this.ptbSao2);
            this.Controls.Add(this.ptbRong1);
            this.Controls.Add(this.frmHuy);
            this.Controls.Add(this.btnGuiPhanHoi);
            this.Controls.Add(this.txtYKien);
            this.Controls.Add(this.ptbSao1);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblYKiem);
            this.Controls.Add(this.lblDanhGia);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblPhanHoiVaDanhGia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhanHoi";
            this.Text = "Feedback";
            this.Load += new System.EventHandler(this.frmPhanHoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRong5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSao5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhanHoiVaDanhGia;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDanhGia;
        private System.Windows.Forms.Label lblYKiem;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox ptbSao1;
        private System.Windows.Forms.TextBox txtYKien;
        private System.Windows.Forms.Button btnGuiPhanHoi;
        private System.Windows.Forms.Button frmHuy;
        private System.Windows.Forms.PictureBox ptbRong1;
        private System.Windows.Forms.PictureBox ptbRong2;
        private System.Windows.Forms.PictureBox ptbSao2;
        private System.Windows.Forms.PictureBox ptbRong3;
        private System.Windows.Forms.PictureBox ptbSao3;
        private System.Windows.Forms.PictureBox ptbRong4;
        private System.Windows.Forms.PictureBox ptbSao4;
        private System.Windows.Forms.PictureBox ptbRong5;
        private System.Windows.Forms.PictureBox ptbSao5;
        private System.Windows.Forms.Button btnLuu;
    }
}