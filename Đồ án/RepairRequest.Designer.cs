namespace Đồ_án
{
    partial class frmBaoTri
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
            this.txtMoTaVanDe = new System.Windows.Forms.TextBox();
            this.lblMoTaVanDe = new System.Windows.Forms.Label();
            this.lblYeuCauBaoTri = new System.Windows.Forms.Label();
            this.lblDoUuTien = new System.Windows.Forms.Label();
            this.cbbDoUuTien = new System.Windows.Forms.ComboBox();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMoTaVanDe
            // 
            this.txtMoTaVanDe.Location = new System.Drawing.Point(91, 158);
            this.txtMoTaVanDe.Multiline = true;
            this.txtMoTaVanDe.Name = "txtMoTaVanDe";
            this.txtMoTaVanDe.Size = new System.Drawing.Size(582, 138);
            this.txtMoTaVanDe.TabIndex = 12;
            // 
            // lblMoTaVanDe
            // 
            this.lblMoTaVanDe.AutoSize = true;
            this.lblMoTaVanDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTaVanDe.Location = new System.Drawing.Point(87, 117);
            this.lblMoTaVanDe.Name = "lblMoTaVanDe";
            this.lblMoTaVanDe.Size = new System.Drawing.Size(110, 20);
            this.lblMoTaVanDe.TabIndex = 11;
            this.lblMoTaVanDe.Text = "Mô tả vấn đề:";
            // 
            // lblYeuCauBaoTri
            // 
            this.lblYeuCauBaoTri.AutoSize = true;
            this.lblYeuCauBaoTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYeuCauBaoTri.Location = new System.Drawing.Point(230, 53);
            this.lblYeuCauBaoTri.Name = "lblYeuCauBaoTri";
            this.lblYeuCauBaoTri.Size = new System.Drawing.Size(294, 42);
            this.lblYeuCauBaoTri.TabIndex = 10;
            this.lblYeuCauBaoTri.Text = "Yêu Cầu Bảo Trì";
            // 
            // lblDoUuTien
            // 
            this.lblDoUuTien.AutoSize = true;
            this.lblDoUuTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoUuTien.Location = new System.Drawing.Point(87, 323);
            this.lblDoUuTien.Name = "lblDoUuTien";
            this.lblDoUuTien.Size = new System.Drawing.Size(90, 20);
            this.lblDoUuTien.TabIndex = 13;
            this.lblDoUuTien.Text = "Độ ưu tiên:";
            // 
            // cbbDoUuTien
            // 
            this.cbbDoUuTien.FormattingEnabled = true;
            this.cbbDoUuTien.Items.AddRange(new object[] {
            "Mức 1 (Hư hỏng nhẹ cần sử chữa thay thế)",
            "Mức 2 (Hư hỏng vừa cần thay thế sớm)",
            "Mức 3 (Hư hỏng nặng cần thay thể sơm nhất có thể)"});
            this.cbbDoUuTien.Location = new System.Drawing.Point(219, 323);
            this.cbbDoUuTien.Name = "cbbDoUuTien";
            this.cbbDoUuTien.Size = new System.Drawing.Size(250, 24);
            this.cbbDoUuTien.TabIndex = 14;
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(114, 417);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(177, 48);
            this.btnGuiYeuCau.TabIndex = 15;
            this.btnGuiYeuCau.Text = "Gửi yêu cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(463, 417);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(177, 48);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhong.Location = new System.Drawing.Point(87, 366);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(84, 20);
            this.lblSoPhong.TabIndex = 17;
            this.lblSoPhong.Text = "Số phòng:";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(219, 366);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(250, 22);
            this.txtSoPhong.TabIndex = 18;
            // 
            // frmBaoTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.cbbDoUuTien);
            this.Controls.Add(this.lblDoUuTien);
            this.Controls.Add(this.txtMoTaVanDe);
            this.Controls.Add(this.lblMoTaVanDe);
            this.Controls.Add(this.lblYeuCauBaoTri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoTri";
            this.Text = "RepairRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMoTaVanDe;
        private System.Windows.Forms.Label lblMoTaVanDe;
        private System.Windows.Forms.Label lblYeuCauBaoTri;
        private System.Windows.Forms.Label lblDoUuTien;
        private System.Windows.Forms.ComboBox cbbDoUuTien;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.TextBox txtSoPhong;
    }
}