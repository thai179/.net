namespace Đồ_án
{
    partial class RoomManagement
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.So_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinh_trang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_luong_sv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.cobArray = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.So_phong,
            this.Loai_phong,
            this.tinh_trang,
            this.so_luong_sv});
            this.dataGridView1.Location = new System.Drawing.Point(78, 164);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(589, 270);
            this.dataGridView1.TabIndex = 25;
            // 
            // So_phong
            // 
            this.So_phong.HeaderText = "Số phòng";
            this.So_phong.MinimumWidth = 6;
            this.So_phong.Name = "So_phong";
            this.So_phong.Width = 125;
            // 
            // Loai_phong
            // 
            this.Loai_phong.HeaderText = "Loại Phòng";
            this.Loai_phong.MinimumWidth = 6;
            this.Loai_phong.Name = "Loai_phong";
            this.Loai_phong.Width = 125;
            // 
            // tinh_trang
            // 
            this.tinh_trang.HeaderText = "Tình trạng";
            this.tinh_trang.MinimumWidth = 6;
            this.tinh_trang.Name = "tinh_trang";
            this.tinh_trang.Width = 125;
            // 
            // so_luong_sv
            // 
            this.so_luong_sv.HeaderText = "Người/Phòng";
            this.so_luong_sv.MinimumWidth = 6;
            this.so_luong_sv.Name = "so_luong_sv";
            this.so_luong_sv.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(451, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Lọc theo:";
            // 
            // cobArray
            // 
            this.cobArray.FormattingEnabled = true;
            this.cobArray.Location = new System.Drawing.Point(539, 120);
            this.cobArray.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cobArray.Name = "cobArray";
            this.cobArray.Size = new System.Drawing.Size(145, 24);
            this.cobArray.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(163, 123);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 22);
            this.txtSearch.TabIndex = 21;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(539, 441);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(128, 43);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(307, 441);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(128, 43);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(78, 441);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(128, 43);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 54);
            this.label1.TabIndex = 17;
            this.label1.Text = "Quản Lý Phòng";
            // 
            // RoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cobArray);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomManagement";
            this.Text = "RoomManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinh_trang;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_luong_sv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cobArray;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
    }
}