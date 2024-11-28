namespace Đồ_án
{
    partial class frmQLTTLienLac
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
            this.lblQLTTLienLac = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblTenTN = new System.Windows.Forms.Label();
            this.lblSDTTN = new System.Windows.Forms.Label();
            this.lblQuanhe = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtTenTN = new System.Windows.Forms.TextBox();
            this.txtSDTTN = new System.Windows.Forms.TextBox();
            this.cbbQuanHe = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHoanTac = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvThanNhan = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanNhan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQLTTLienLac
            // 
            this.lblQLTTLienLac.AutoSize = true;
            this.lblQLTTLienLac.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLTTLienLac.Location = new System.Drawing.Point(96, 32);
            this.lblQLTTLienLac.Name = "lblQLTTLienLac";
            this.lblQLTTLienLac.Size = new System.Drawing.Size(562, 51);
            this.lblQLTTLienLac.TabIndex = 43;
            this.lblQLTTLienLac.Text = "Quản Lý Thông Tin Liên Lạc";
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(78, 100);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(61, 20);
            this.lblMSSV.TabIndex = 44;
            this.lblMSSV.Text = "MSSV:";
            // 
            // lblTenTN
            // 
            this.lblTenTN.AutoSize = true;
            this.lblTenTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTN.Location = new System.Drawing.Point(78, 139);
            this.lblTenTN.Name = "lblTenTN";
            this.lblTenTN.Size = new System.Drawing.Size(120, 20);
            this.lblTenTN.TabIndex = 45;
            this.lblTenTN.Text = "Tên thân nhân:";
            // 
            // lblSDTTN
            // 
            this.lblSDTTN.AutoSize = true;
            this.lblSDTTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTTN.Location = new System.Drawing.Point(78, 178);
            this.lblSDTTN.Name = "lblSDTTN";
            this.lblSDTTN.Size = new System.Drawing.Size(125, 20);
            this.lblSDTTN.TabIndex = 46;
            this.lblSDTTN.Text = "SĐT thân nhân:";
            // 
            // lblQuanhe
            // 
            this.lblQuanhe.AutoSize = true;
            this.lblQuanhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanhe.Location = new System.Drawing.Point(78, 217);
            this.lblQuanhe.Name = "lblQuanhe";
            this.lblQuanhe.Size = new System.Drawing.Size(77, 20);
            this.lblQuanhe.TabIndex = 47;
            this.lblQuanhe.Text = "Quan hệ:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(250, 100);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(421, 22);
            this.txtMSSV.TabIndex = 48;
            // 
            // txtTenTN
            // 
            this.txtTenTN.Location = new System.Drawing.Point(250, 139);
            this.txtTenTN.Name = "txtTenTN";
            this.txtTenTN.Size = new System.Drawing.Size(421, 22);
            this.txtTenTN.TabIndex = 49;
            // 
            // txtSDTTN
            // 
            this.txtSDTTN.Location = new System.Drawing.Point(250, 178);
            this.txtSDTTN.Name = "txtSDTTN";
            this.txtSDTTN.Size = new System.Drawing.Size(421, 22);
            this.txtSDTTN.TabIndex = 50;
            // 
            // cbbQuanHe
            // 
            this.cbbQuanHe.FormattingEnabled = true;
            this.cbbQuanHe.Location = new System.Drawing.Point(250, 217);
            this.cbbQuanHe.Name = "cbbQuanHe";
            this.cbbQuanHe.Size = new System.Drawing.Size(218, 24);
            this.cbbQuanHe.TabIndex = 51;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(125, 388);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 52);
            this.btnThem.TabIndex = 52;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(310, 388);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 52);
            this.btnXoa.TabIndex = 53;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(495, 388);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 52);
            this.btnSua.TabIndex = 54;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHoanTac
            // 
            this.btnHoanTac.Location = new System.Drawing.Point(125, 461);
            this.btnHoanTac.Name = "btnHoanTac";
            this.btnHoanTac.Size = new System.Drawing.Size(135, 52);
            this.btnHoanTac.TabIndex = 55;
            this.btnHoanTac.Text = "Hoàn tác";
            this.btnHoanTac.UseVisualStyleBackColor = true;
            this.btnHoanTac.Click += new System.EventHandler(this.btnHoanTac_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(310, 461);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(135, 52);
            this.btnLuu.TabIndex = 56;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvThanNhan
            // 
            this.dgvThanNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanNhan.Location = new System.Drawing.Point(81, 247);
            this.dgvThanNhan.Name = "dgvThanNhan";
            this.dgvThanNhan.RowHeadersWidth = 51;
            this.dgvThanNhan.RowTemplate.Height = 24;
            this.dgvThanNhan.Size = new System.Drawing.Size(598, 127);
            this.dgvThanNhan.TabIndex = 57;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(495, 461);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 52);
            this.btnRefresh.TabIndex = 58;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmQLTTLienLac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvThanNhan);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHoanTac);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbbQuanHe);
            this.Controls.Add(this.txtSDTTN);
            this.Controls.Add(this.txtTenTN);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.lblQuanhe);
            this.Controls.Add(this.lblSDTTN);
            this.Controls.Add(this.lblTenTN);
            this.Controls.Add(this.lblMSSV);
            this.Controls.Add(this.lblQLTTLienLac);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQLTTLienLac";
            this.Text = "ContactInformation";
            this.Load += new System.EventHandler(this.frmQLTTLienLac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanNhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQLTTLienLac;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblTenTN;
        private System.Windows.Forms.Label lblSDTTN;
        private System.Windows.Forms.Label lblQuanhe;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtTenTN;
        private System.Windows.Forms.TextBox txtSDTTN;
        private System.Windows.Forms.ComboBox cbbQuanHe;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHoanTac;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvThanNhan;
        private System.Windows.Forms.Button btnRefresh;
    }
}