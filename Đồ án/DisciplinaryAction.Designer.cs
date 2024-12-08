namespace Đồ_án
{
    partial class frmViPham
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
            this.lblGhiNhanViPham = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.lblMoTaViPham = new System.Windows.Forms.Label();
            this.lblHinhThucXuLy = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.txtMoTaViPham = new System.Windows.Forms.TextBox();
            this.cbbHinhThucXuLy = new System.Windows.Forms.ComboBox();
            this.btnGhiNhan = new System.Windows.Forms.Button();
            this.btnHoanTac = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGhiNhanViPham
            // 
            this.lblGhiNhanViPham.AutoSize = true;
            this.lblGhiNhanViPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiNhanViPham.Location = new System.Drawing.Point(177, 27);
            this.lblGhiNhanViPham.Name = "lblGhiNhanViPham";
            this.lblGhiNhanViPham.Size = new System.Drawing.Size(377, 51);
            this.lblGhiNhanViPham.TabIndex = 44;
            this.lblGhiNhanViPham.Text = "Ghi Nhận Vi Phạm";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(67, 110);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(61, 20);
            this.lblMSSV.TabIndex = 45;
            this.lblMSSV.Text = "MSSV:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(67, 151);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(69, 20);
            this.lblHoTen.TabIndex = 46;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhong.Location = new System.Drawing.Point(67, 192);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(84, 20);
            this.lblSoPhong.TabIndex = 47;
            this.lblSoPhong.Text = "Số phòng:";
            // 
            // lblMoTaViPham
            // 
            this.lblMoTaViPham.AutoSize = true;
            this.lblMoTaViPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTaViPham.Location = new System.Drawing.Point(67, 233);
            this.lblMoTaViPham.Name = "lblMoTaViPham";
            this.lblMoTaViPham.Size = new System.Drawing.Size(119, 20);
            this.lblMoTaViPham.TabIndex = 48;
            this.lblMoTaViPham.Text = "Mô tả vi phạm:";
            // 
            // lblHinhThucXuLy
            // 
            this.lblHinhThucXuLy.AutoSize = true;
            this.lblHinhThucXuLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThucXuLy.Location = new System.Drawing.Point(67, 359);
            this.lblHinhThucXuLy.Name = "lblHinhThucXuLy";
            this.lblHinhThucXuLy.Size = new System.Drawing.Size(125, 20);
            this.lblHinhThucXuLy.TabIndex = 49;
            this.lblHinhThucXuLy.Text = "Hình thức xử lý:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(220, 108);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(430, 22);
            this.txtMSSV.TabIndex = 50;
            this.txtMSSV.Leave += new System.EventHandler(this.txtMSSV_Leave);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(220, 149);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(430, 22);
            this.txtHoTen.TabIndex = 51;
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(220, 190);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(430, 22);
            this.txtSoPhong.TabIndex = 52;
            // 
            // txtMoTaViPham
            // 
            this.txtMoTaViPham.Location = new System.Drawing.Point(71, 256);
            this.txtMoTaViPham.Multiline = true;
            this.txtMoTaViPham.Name = "txtMoTaViPham";
            this.txtMoTaViPham.Size = new System.Drawing.Size(579, 83);
            this.txtMoTaViPham.TabIndex = 53;
            // 
            // cbbHinhThucXuLy
            // 
            this.cbbHinhThucXuLy.FormattingEnabled = true;
            this.cbbHinhThucXuLy.Items.AddRange(new object[] {
            "Cảnh cáo",
            "Tạm đình chỉ",
            "Đuổi khỏi ký túc xá"});
            this.cbbHinhThucXuLy.Location = new System.Drawing.Point(220, 359);
            this.cbbHinhThucXuLy.Name = "cbbHinhThucXuLy";
            this.cbbHinhThucXuLy.Size = new System.Drawing.Size(275, 24);
            this.cbbHinhThucXuLy.TabIndex = 54;
            // 
            // btnGhiNhan
            // 
            this.btnGhiNhan.Location = new System.Drawing.Point(46, 433);
            this.btnGhiNhan.Name = "btnGhiNhan";
            this.btnGhiNhan.Size = new System.Drawing.Size(147, 49);
            this.btnGhiNhan.TabIndex = 55;
            this.btnGhiNhan.Text = "Ghi nhận vi phạm";
            this.btnGhiNhan.UseVisualStyleBackColor = true;
            this.btnGhiNhan.Click += new System.EventHandler(this.btnGhiNhan_Click);
            // 
            // btnHoanTac
            // 
            this.btnHoanTac.Location = new System.Drawing.Point(390, 433);
            this.btnHoanTac.Name = "btnHoanTac";
            this.btnHoanTac.Size = new System.Drawing.Size(147, 49);
            this.btnHoanTac.TabIndex = 56;
            this.btnHoanTac.Text = "Hoàn tác";
            this.btnHoanTac.UseVisualStyleBackColor = true;
            this.btnHoanTac.Click += new System.EventHandler(this.btnHoanTac_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(218, 433);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(147, 49);
            this.btnClear.TabIndex = 57;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(562, 433);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(147, 49);
            this.btnLuu.TabIndex = 58;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmViPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHoanTac);
            this.Controls.Add(this.btnGhiNhan);
            this.Controls.Add(this.cbbHinhThucXuLy);
            this.Controls.Add(this.txtMoTaViPham);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.lblHinhThucXuLy);
            this.Controls.Add(this.lblMoTaViPham);
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.lblGhiNhanViPham);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViPham";
            this.Text = "DisciplinaryAction";
            this.Load += new System.EventHandler(this.frmViPham_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGhiNhanViPham;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.Label lblMoTaViPham;
        private System.Windows.Forms.Label lblHinhThucXuLy;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.TextBox txtMoTaViPham;
        private System.Windows.Forms.ComboBox cbbHinhThucXuLy;
        private System.Windows.Forms.Button btnGhiNhan;
        private System.Windows.Forms.Button btnHoanTac;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLuu;
    }
}