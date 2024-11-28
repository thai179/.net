namespace Đồ_án
{
    partial class frmSuaPhong
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
            this.cbbTinhTrang = new System.Windows.Forms.ComboBox();
            this.cbbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.txtSoNguoi = new System.Windows.Forms.TextBox();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnCLear = new System.Windows.Forms.Button();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.lblSuaPhong = new System.Windows.Forms.Label();
            this.ptbTim = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTim)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbTinhTrang
            // 
            this.cbbTinhTrang.FormattingEnabled = true;
            this.cbbTinhTrang.Items.AddRange(new object[] {
            "Còn trống",
            "Đủ người"});
            this.cbbTinhTrang.Location = new System.Drawing.Point(213, 216);
            this.cbbTinhTrang.Name = "cbbTinhTrang";
            this.cbbTinhTrang.Size = new System.Drawing.Size(146, 24);
            this.cbbTinhTrang.TabIndex = 25;
            // 
            // cbbLoaiPhong
            // 
            this.cbbLoaiPhong.FormattingEnabled = true;
            this.cbbLoaiPhong.Items.AddRange(new object[] {
            "Đơn",
            "Tập thể"});
            this.cbbLoaiPhong.Location = new System.Drawing.Point(213, 162);
            this.cbbLoaiPhong.Name = "cbbLoaiPhong";
            this.cbbLoaiPhong.Size = new System.Drawing.Size(146, 24);
            this.cbbLoaiPhong.TabIndex = 24;
            // 
            // txtSoNguoi
            // 
            this.txtSoNguoi.Location = new System.Drawing.Point(213, 273);
            this.txtSoNguoi.Name = "txtSoNguoi";
            this.txtSoNguoi.Size = new System.Drawing.Size(397, 22);
            this.txtSoNguoi.TabIndex = 23;
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(213, 108);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(369, 22);
            this.txtSoPhong.TabIndex = 22;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(489, 326);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(121, 37);
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(279, 326);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(121, 37);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnCLear
            // 
            this.btnCLear.Location = new System.Drawing.Point(69, 326);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(121, 37);
            this.btnCLear.TabIndex = 19;
            this.btnCLear.Text = "Clear";
            this.btnCLear.UseVisualStyleBackColor = true;
            this.btnCLear.Click += new System.EventHandler(this.btnCLear_Click);
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoNguoi.Location = new System.Drawing.Point(58, 273);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(79, 20);
            this.lblSoNguoi.TabIndex = 18;
            this.lblSoNguoi.Text = "Số người:";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhTrang.Location = new System.Drawing.Point(58, 220);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(89, 20);
            this.lblTinhTrang.TabIndex = 17;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiPhong.Location = new System.Drawing.Point(58, 162);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(96, 20);
            this.lblLoaiPhong.TabIndex = 16;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhong.Location = new System.Drawing.Point(58, 110);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(84, 20);
            this.lblSoPhong.TabIndex = 15;
            this.lblSoPhong.Text = "Số phòng:";
            // 
            // lblSuaPhong
            // 
            this.lblSuaPhong.AutoSize = true;
            this.lblSuaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuaPhong.Location = new System.Drawing.Point(223, 27);
            this.lblSuaPhong.Name = "lblSuaPhong";
            this.lblSuaPhong.Size = new System.Drawing.Size(204, 42);
            this.lblSuaPhong.TabIndex = 14;
            this.lblSuaPhong.Text = "Sửa Phòng";
            // 
            // ptbTim
            // 
            this.ptbTim.Image = global::Đồ_án.Properties.Resources.kính_lúp;
            this.ptbTim.Location = new System.Drawing.Point(588, 108);
            this.ptbTim.Name = "ptbTim";
            this.ptbTim.Size = new System.Drawing.Size(22, 22);
            this.ptbTim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbTim.TabIndex = 26;
            this.ptbTim.TabStop = false;
            this.ptbTim.Click += new System.EventHandler(this.ptbTim_Click);
            // 
            // frmSuaPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 391);
            this.Controls.Add(this.ptbTim);
            this.Controls.Add(this.cbbTinhTrang);
            this.Controls.Add(this.cbbLoaiPhong);
            this.Controls.Add(this.txtSoNguoi);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnCLear);
            this.Controls.Add(this.lblSoNguoi);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.lblSuaPhong);
            this.Name = "frmSuaPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa_phòng";
            ((System.ComponentModel.ISupportInitialize)(this.ptbTim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbTinhTrang;
        private System.Windows.Forms.ComboBox cbbLoaiPhong;
        private System.Windows.Forms.TextBox txtSoNguoi;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnCLear;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.Label lblSuaPhong;
        private System.Windows.Forms.PictureBox ptbTim;
    }
}