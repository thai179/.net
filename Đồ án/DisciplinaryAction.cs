﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmViPham : Form
    {
        private DataSet dsViPham;
        private DataSet dsViPhamGoc;
        public frmViPham()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsViPham = new DataSet();
            dsViPhamGoc = new DataSet();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMoTaViPham.Text = "";
            txtMSSV.Text = "";
            txtSoPhong.Text = "";
            cbbHinhThucXuLy.SelectedIndex = 0;
        }

        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text =="")
            {
                MessageBox.Show("ban chua nhap so phong", "thong bao");
                txtSoPhong.Focus();
                return;
            }
            if (txtMoTaViPham.Text =="")
            {
                MessageBox.Show("ban chua mo ta vi pham cua sinh vien");
                txtMoTaViPham.Focus();
                return;
            }
            if (cbbHinhThucXuLy.Text =="")
            {
                MessageBox.Show("ban chua chon hinh thuc su ly");
                cbbHinhThucXuLy.Focus();
                return;
            }
            DataTable dataTable = dsViPham.Tables["ViPham"];
            DataRow newRow = dataTable.NewRow();
            newRow["ndvp"] = txtMoTaViPham.Text;
            newRow["sophong"] = txtSoPhong.Text;
            newRow["masv"] = txtMSSV.Text;
            newRow["htxuly"] = cbbHinhThucXuLy.Text;
            dataTable.Rows.Add(newRow);
            MessageBox.Show("Vi phạm đã được ghi nhận vào DataSet");
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMSSV.Text))
            {
                string mssv = txtMSSV.Text;

                string query = "select hoten, sophong from sinhvien where masv = @mssv";
                using(SqlConnection conn = ConnectionManager.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query,conn);
                    cmd.Parameters.AddWithValue("@mssv",mssv);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["hoten"].ToString();
                        txtSoPhong.Text = reader["SoPhong"].ToString();
                    }
                    else
                        MessageBox.Show("Ma so sinh vien khong ton tai", "thong bao");
                    reader.Close();
                }
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bận có muốn hoàn tác các thay đổi hay không","Thông báo",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dsViPham = dsViPhamGoc.Copy();
                MessageBox.Show("Đã hoàn tác các thay đổi.");
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dsViPham.GetChanges() == null)
            {
                MessageBox.Show("Không có thay đổi để lưu.");
                return;
            }

            try
            {
                SqlConnection conn = ConnectionManager.GetConnection();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM thongtinvipham", conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                if (commandBuilder.GetInsertCommand() == null || commandBuilder.GetUpdateCommand() == null || commandBuilder.GetDeleteCommand() == null)
                {
                    MessageBox.Show("Không thể tự động tạo các câu lệnh SQL.");
                    return;
                }
                dataAdapter.Update(dsViPham, "ViPham");
                dsViPham.AcceptChanges();

                MessageBox.Show("Dữ liệu đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void frmViPham_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM thongtinvipham";
            SqlDataAdapter adapter = new SqlDataAdapter(query, ConnectionManager.GetConnection());
            adapter.Fill(dsViPhamGoc, "ViPham");
            dsViPham = dsViPhamGoc.Copy();
        }
    }
}
