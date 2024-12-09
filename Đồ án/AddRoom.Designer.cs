namespace Đồ_án
{
    partial class frmThemPhong
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
            this.lblThemPhong = new System.Windows.Forms.Label();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.txtSoNguoi = new System.Windows.Forms.TextBox();
            this.cbbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.cbbTinhTrang = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblThemPhong
            // 
            this.lblThemPhong.AutoSize = true;
            this.lblThemPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemPhong.Location = new System.Drawing.Point(218, 9);
            this.lblThemPhong.Name = "lblThemPhong";
            this.lblThemPhong.Size = new System.Drawing.Size(232, 42);
            this.lblThemPhong.TabIndex = 0;
            this.lblThemPhong.Text = "Thêm Phòng";
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhong.Location = new System.Drawing.Point(53, 92);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(84, 20);
            this.lblSoPhong.TabIndex = 1;
            this.lblSoPhong.Text = "Số phòng:";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiPhong.Location = new System.Drawing.Point(53, 144);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(96, 20);
            this.lblLoaiPhong.TabIndex = 2;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhTrang.Location = new System.Drawing.Point(53, 202);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(89, 20);
            this.lblTinhTrang.TabIndex = 3;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoNguoi.Location = new System.Drawing.Point(53, 255);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(79, 20);
            this.lblSoNguoi.TabIndex = 4;
            this.lblSoNguoi.Text = "Số người:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(64, 308);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(121, 37);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(274, 308);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(121, 37);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(484, 308);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(121, 37);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(208, 90);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(397, 22);
            this.txtSoPhong.TabIndex = 8;
            // 
            // txtSoNguoi
            // 
            this.txtSoNguoi.Location = new System.Drawing.Point(208, 255);
            this.txtSoNguoi.Name = "txtSoNguoi";
            this.txtSoNguoi.Size = new System.Drawing.Size(397, 22);
            this.txtSoNguoi.TabIndex = 11;
            // 
            // cbbLoaiPhong
            // 
            this.cbbLoaiPhong.FormattingEnabled = true;
            this.cbbLoaiPhong.Items.AddRange(new object[] {
            "Đơn",
            "Tập thể"});
            this.cbbLoaiPhong.Location = new System.Drawing.Point(208, 144);
            this.cbbLoaiPhong.Name = "cbbLoaiPhong";
            this.cbbLoaiPhong.Size = new System.Drawing.Size(146, 24);
            this.cbbLoaiPhong.TabIndex = 12;
            // 
            // cbbTinhTrang
            // 
            this.cbbTinhTrang.FormattingEnabled = true;
            this.cbbTinhTrang.Items.AddRange(new object[] {
            "Còn trống",
            "Đang bảo trì"});
            this.cbbTinhTrang.Location = new System.Drawing.Point(208, 198);
            this.cbbTinhTrang.Name = "cbbTinhTrang";
            this.cbbTinhTrang.Size = new System.Drawing.Size(146, 24);
            this.cbbTinhTrang.TabIndex = 13;
            // 
            // frmThemPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(669, 391);
            this.Controls.Add(this.cbbTinhTrang);
            this.Controls.Add(this.cbbLoaiPhong);
            this.Controls.Add(this.txtSoNguoi);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSoNguoi);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.lblThemPhong);
            this.Name = "frmThemPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm phòng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThemPhong;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.TextBox txtSoNguoi;
        private System.Windows.Forms.ComboBox cbbLoaiPhong;
        private System.Windows.Forms.ComboBox cbbTinhTrang;
    }
}