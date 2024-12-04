namespace Đồ_án
{
    partial class frmThanhToan
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
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.lblSoTienThanhToan = new System.Windows.Forms.Label();
            this.lblNgayThanhToan = new System.Windows.Forms.Label();
            this.btnXacNhanThanhToan = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.txtSoTienThanhToan = new System.Windows.Forms.TextBox();
            this.dtpNgayThanhToan = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblLoaiThanhToan = new System.Windows.Forms.Label();
            this.cbbLoaiThanhToan = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblThanhToan
            // 
            this.lblThanhToan.AutoSize = true;
            this.lblThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhToan.Location = new System.Drawing.Point(267, 41);
            this.lblThanhToan.Name = "lblThanhToan";
            this.lblThanhToan.Size = new System.Drawing.Size(221, 42);
            this.lblThanhToan.TabIndex = 0;
            this.lblThanhToan.Text = "Thanh Toán";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(92, 157);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(69, 20);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(92, 107);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(61, 20);
            this.lblMSSV.TabIndex = 2;
            this.lblMSSV.Text = "MSSV:";
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhong.Location = new System.Drawing.Point(92, 209);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(84, 20);
            this.lblSoPhong.TabIndex = 3;
            this.lblSoPhong.Text = "Số phòng:";
            // 
            // lblSoTienThanhToan
            // 
            this.lblSoTienThanhToan.AutoSize = true;
            this.lblSoTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienThanhToan.Location = new System.Drawing.Point(92, 257);
            this.lblSoTienThanhToan.Name = "lblSoTienThanhToan";
            this.lblSoTienThanhToan.Size = new System.Drawing.Size(149, 20);
            this.lblSoTienThanhToan.TabIndex = 5;
            this.lblSoTienThanhToan.Text = "Số tiền thanh toán:";
            // 
            // lblNgayThanhToan
            // 
            this.lblNgayThanhToan.AutoSize = true;
            this.lblNgayThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThanhToan.Location = new System.Drawing.Point(92, 309);
            this.lblNgayThanhToan.Name = "lblNgayThanhToan";
            this.lblNgayThanhToan.Size = new System.Drawing.Size(135, 20);
            this.lblNgayThanhToan.TabIndex = 6;
            this.lblNgayThanhToan.Text = "Ngày thanh toán:";
            // 
            // btnXacNhanThanhToan
            // 
            this.btnXacNhanThanhToan.Location = new System.Drawing.Point(175, 433);
            this.btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            this.btnXacNhanThanhToan.Size = new System.Drawing.Size(149, 48);
            this.btnXacNhanThanhToan.TabIndex = 7;
            this.btnXacNhanThanhToan.Text = "Xác nhận thanh toán";
            this.btnXacNhanThanhToan.UseVisualStyleBackColor = true;
            this.btnXacNhanThanhToan.Click += new System.EventHandler(this.btnXacNhanThanhToan_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(430, 433);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(149, 48);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(266, 155);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(406, 22);
            this.txtHoTen.TabIndex = 9;
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(266, 105);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(406, 22);
            this.txtMSSV.TabIndex = 10;
            this.txtMSSV.Leave += new System.EventHandler(this.txtMSSV_Leave);
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(266, 207);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(406, 22);
            this.txtSoPhong.TabIndex = 11;
            // 
            // txtSoTienThanhToan
            // 
            this.txtSoTienThanhToan.Location = new System.Drawing.Point(266, 255);
            this.txtSoTienThanhToan.Name = "txtSoTienThanhToan";
            this.txtSoTienThanhToan.Size = new System.Drawing.Size(406, 22);
            this.txtSoTienThanhToan.TabIndex = 12;
            this.txtSoTienThanhToan.Leave += new System.EventHandler(this.txtSoTienThanhToan_Leave);
            // 
            // dtpNgayThanhToan
            // 
            this.dtpNgayThanhToan.Location = new System.Drawing.Point(266, 307);
            this.dtpNgayThanhToan.Name = "dtpNgayThanhToan";
            this.dtpNgayThanhToan.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayThanhToan.TabIndex = 15;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(266, 351);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(406, 22);
            this.txtGhiChu.TabIndex = 17;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(92, 353);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(72, 20);
            this.lblGhiChu.TabIndex = 16;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // lblLoaiThanhToan
            // 
            this.lblLoaiThanhToan.AutoSize = true;
            this.lblLoaiThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiThanhToan.Location = new System.Drawing.Point(92, 395);
            this.lblLoaiThanhToan.Name = "lblLoaiThanhToan";
            this.lblLoaiThanhToan.Size = new System.Drawing.Size(129, 20);
            this.lblLoaiThanhToan.TabIndex = 18;
            this.lblLoaiThanhToan.Text = "Loại thanh toán:";
            // 
            // cbbLoaiThanhToan
            // 
            this.cbbLoaiThanhToan.FormattingEnabled = true;
            this.cbbLoaiThanhToan.Items.AddRange(new object[] {
            "Điện-Nước",
            "Phí KTX"});
            this.cbbLoaiThanhToan.Location = new System.Drawing.Point(266, 395);
            this.cbbLoaiThanhToan.Name = "cbbLoaiThanhToan";
            this.cbbLoaiThanhToan.Size = new System.Drawing.Size(278, 24);
            this.cbbLoaiThanhToan.TabIndex = 19;
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.cbbLoaiThanhToan);
            this.Controls.Add(this.lblLoaiThanhToan);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.dtpNgayThanhToan);
            this.Controls.Add(this.txtSoTienThanhToan);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnXacNhanThanhToan);
            this.Controls.Add(this.lblNgayThanhToan);
            this.Controls.Add(this.lblSoTienThanhToan);
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblThanhToan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThanhToan";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThanhToan;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.Label lblSoTienThanhToan;
        private System.Windows.Forms.Label lblNgayThanhToan;
        private System.Windows.Forms.Button btnXacNhanThanhToan;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.TextBox txtSoTienThanhToan;
        private System.Windows.Forms.DateTimePicker dtpNgayThanhToan;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblLoaiThanhToan;
        private System.Windows.Forms.ComboBox cbbLoaiThanhToan;
    }
}