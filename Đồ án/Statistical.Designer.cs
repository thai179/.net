namespace Đồ_án
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.lblBieuDoThongKe = new System.Windows.Forms.Label();
            this.lblThongKeChiTiet = new System.Windows.Forms.Label();
            this.btnXuatThongKe = new System.Windows.Forms.Button();
            this.cbbChonDanVanBan = new System.Windows.Forms.ComboBox();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.chartThongKeDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartThongKeSinhVien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongKe
            // 
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongKe.Location = new System.Drawing.Point(264, 23);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(192, 46);
            this.lblThongKe.TabIndex = 0;
            this.lblThongKe.Text = "Thống Kê";
            // 
            // lblBieuDoThongKe
            // 
            this.lblBieuDoThongKe.AutoSize = true;
            this.lblBieuDoThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBieuDoThongKe.Location = new System.Drawing.Point(67, 104);
            this.lblBieuDoThongKe.Name = "lblBieuDoThongKe";
            this.lblBieuDoThongKe.Size = new System.Drawing.Size(139, 20);
            this.lblBieuDoThongKe.TabIndex = 1;
            this.lblBieuDoThongKe.Text = "Biểu đồ thống kê:";
            // 
            // lblThongKeChiTiet
            // 
            this.lblThongKeChiTiet.AutoSize = true;
            this.lblThongKeChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongKeChiTiet.Location = new System.Drawing.Point(62, 287);
            this.lblThongKeChiTiet.Name = "lblThongKeChiTiet";
            this.lblThongKeChiTiet.Size = new System.Drawing.Size(137, 20);
            this.lblThongKeChiTiet.TabIndex = 2;
            this.lblThongKeChiTiet.Text = "Thống kê chi tiết:";
            // 
            // btnXuatThongKe
            // 
            this.btnXuatThongKe.Location = new System.Drawing.Point(108, 432);
            this.btnXuatThongKe.Name = "btnXuatThongKe";
            this.btnXuatThongKe.Size = new System.Drawing.Size(141, 50);
            this.btnXuatThongKe.TabIndex = 3;
            this.btnXuatThongKe.Text = "Xuất thống kê";
            this.btnXuatThongKe.UseVisualStyleBackColor = true;
            this.btnXuatThongKe.Click += new System.EventHandler(this.btnXuatThongKe_Click);
            // 
            // cbbChonDanVanBan
            // 
            this.cbbChonDanVanBan.FormattingEnabled = true;
            this.cbbChonDanVanBan.Items.AddRange(new object[] {
            "Word",
            "PDF"});
            this.cbbChonDanVanBan.Location = new System.Drawing.Point(255, 458);
            this.cbbChonDanVanBan.Name = "cbbChonDanVanBan";
            this.cbbChonDanVanBan.Size = new System.Drawing.Size(147, 24);
            this.cbbChonDanVanBan.TabIndex = 4;
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetThuc.Location = new System.Drawing.Point(456, 104);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(44, 20);
            this.lblKetThuc.TabIndex = 5;
            this.lblKetThuc.Text = "Đến:";
            // 
            // lblBatDau
            // 
            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatDau.Location = new System.Drawing.Point(212, 104);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(38, 20);
            this.lblBatDau.TabIndex = 6;
            this.lblBatDau.Text = "Từ :";
            // 
            // chartThongKeDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThongKeDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKeDoanhThu.Legends.Add(legend1);
            this.chartThongKeDoanhThu.Location = new System.Drawing.Point(65, 149);
            this.chartThongKeDoanhThu.Name = "chartThongKeDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Thanh Toán";
            this.chartThongKeDoanhThu.Series.Add(series1);
            this.chartThongKeDoanhThu.Size = new System.Drawing.Size(304, 129);
            this.chartThongKeDoanhThu.TabIndex = 8;
            this.chartThongKeDoanhThu.Text = "Biểu đồ thống kê doanh thu";
            // 
            // chartThongKeSinhVien
            // 
            chartArea2.Name = "ChartArea1";
            this.chartThongKeSinhVien.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThongKeSinhVien.Legends.Add(legend2);
            this.chartThongKeSinhVien.Location = new System.Drawing.Point(386, 149);
            this.chartThongKeSinhVien.Name = "chartThongKeSinhVien";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Sinh Viên";
            this.chartThongKeSinhVien.Series.Add(series2);
            this.chartThongKeSinhVien.Size = new System.Drawing.Size(304, 129);
            this.chartThongKeSinhVien.TabIndex = 9;
            this.chartThongKeSinhVien.Text = "Biểu đồ thống kê sinh viên";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(76, 310);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.Size = new System.Drawing.Size(603, 103);
            this.dgvThongKe.TabIndex = 10;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Location = new System.Drawing.Point(259, 102);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(186, 22);
            this.dtpBatDau.TabIndex = 11;
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Location = new System.Drawing.Point(505, 104);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(184, 22);
            this.dtpKetThuc.TabIndex = 12;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(505, 432);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(141, 50);
            this.btnThongKe.TabIndex = 13;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(755, 525);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpKetThuc);
            this.Controls.Add(this.dtpBatDau);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.chartThongKeSinhVien);
            this.Controls.Add(this.chartThongKeDoanhThu);
            this.Controls.Add(this.lblBatDau);
            this.Controls.Add(this.lblKetThuc);
            this.Controls.Add(this.cbbChonDanVanBan);
            this.Controls.Add(this.btnXuatThongKe);
            this.Controls.Add(this.lblThongKeChiTiet);
            this.Controls.Add(this.lblBieuDoThongKe);
            this.Controls.Add(this.lblThongKe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.Text = "statistical";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Label lblBieuDoThongKe;
        private System.Windows.Forms.Label lblThongKeChiTiet;
        private System.Windows.Forms.Button btnXuatThongKe;
        private System.Windows.Forms.ComboBox cbbChonDanVanBan;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeSinhVien;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Button btnThongKe;
    }
}