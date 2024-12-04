using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmThanhToan : Form
    {
        DataSet dsThanhToan;
        DataSet dsThanhToanGoc;
        DataTable dtThanhToan;
        public frmThanhToan()
        {
            InitializeComponent();
            this.TopLevel = false;
            dsThanhToan = new DataSet();
            dsThanhToanGoc = new DataSet();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from thanhtoan",ConnectionManager.GetConnection());
            adapter.Fill(dsThanhToanGoc, "thanhtoan");
            dsThanhToan = dsThanhToanGoc.Copy();
            dtThanhToan = dsThanhToan.Tables["thanhtoan"];
        }

        private string ChuanHoaGhiChu(string ghiChu)
        {
            ghiChu = ghiChu.Trim();
            ghiChu = ghiChu.ToLower();
            ghiChu = string.Join(". ", ghiChu.Split('.').Select(s => s.Trim()).Select(s => char.ToUpper(s[0]) + s.Substring(1)));

            return ghiChu;
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtSoPhong.Text) || string.IsNullOrEmpty(txtSoTienThanhToan.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ghiChu = ChuanHoaGhiChu(txtGhiChu.Text);
            txtGhiChu.Text = ghiChu;
            string soTienText = txtSoTienThanhToan.Text;
            soTienText = soTienText.Replace(",", "").Replace("₫", "").Trim();
            decimal soTien;
            if (!decimal.TryParse(soTienText, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ, vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow newRow = dtThanhToan.NewRow();

            newRow["masv"] = txtMSSV.Text;
            newRow["sophong"] = txtSoPhong.Text;
            newRow["loai_thanh_toan"] = cbbLoaiThanhToan.SelectedItem.ToString();
            newRow["ngaylap"] = dtpNgayThanhToan.Value;
            newRow["sotien"] = soTien;
            newRow["ghichu"] = ghiChu;

            dtThanhToan.Rows.Add(newRow);

            // Tạo SqlDataAdapter và thực hiện cập nhật vào cơ sở dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM thanhtoan", ConnectionManager.GetConnection());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            try
            {
                // Cập nhật dữ liệu vào cơ sở dữ liệu
                adapter.Update(dtThanhToan);
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtHoTen.Text = "";
            txtGhiChu.Text = "";
            txtSoPhong.Text = "";
            txtSoTienThanhToan.Text = "";
            dtpNgayThanhToan.Value = DateTime.Now;
            cbbLoaiThanhToan.SelectedIndex = -1;
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã số sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "select * from sinhvien where masv = @masv";
            try
            {
                using (SqlConnection conn = ConnectionManager.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@masv", txtMSSV.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Đọc dữ liệu
                        reader.Read();

                        // Gán giá trị cho các TextBox tương ứng
                        txtHoTen.Text = reader["hoten"].ToString();
                        txtSoPhong.Text = reader["sophong"].ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với MSSV: " + txtMSSV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoTienThanhToan_Leave(object sender, EventArgs e)
        {
            decimal soTien;
            if (decimal.TryParse(txtSoTienThanhToan.Text, out soTien))
            {
                txtSoTienThanhToan.Text = soTien.ToString("C", new CultureInfo("vi-VN"));
            }
            else
            {
                MessageBox.Show("Số tiền không hợp lệ.");

            }
        }
    }
}
