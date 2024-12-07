using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmQLSV : Form
    {
        private SinhVienBLL sinhVienBLL;
        public frmQLSV()
        {
            InitializeComponent();
            this.TopLevel = false;
            sinhVienBLL = new SinhVienBLL();
            sinhVienBLL.LoadSV();
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
        }

        private bool KiemTraDuLieu()
        {
            // Kiểm tra các TextBox có rỗng không
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống.");
                txtMSSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Họ tên không được để trống.");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("Căn cước công dân không được để trống.");
                txtCCCD.Focus();
                return false;
            }
            if (txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("Căn cước công dân không hợp lệ.");
                txtCCCD.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.");
                txtSDT.Focus();
                return false;
            }
            string sdtChuan = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            if (!Regex.IsMatch(txtSDT.Text.Trim(), sdtChuan))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống.");
                txtSoPhong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Mã người dùng không được để trống.");
                txtMaND.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChiChiTiet.Text))
            {
                MessageBox.Show("Địa chỉ chi tiết không được để trống.");
                txtDiaChiChiTiet.Focus();
                return false;
            }

            // Kiểm tra ComboBox có được chọn không
            if (string.IsNullOrEmpty(cbbTinh.Text))
            {
                MessageBox.Show("Vui lòng chọn tỉnh.");
                cbbTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbbQuanHuyen.Text))
            {
                MessageBox.Show("Vui lòng chọn quận/huyện.");
                cbbQuanHuyen.Focus();
                return false;
            }

            // Kiểm tra DateTimePicker có giá trị hợp lệ không
            if (dtpNgaySinh.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.");
                dtpNgaySinh.Focus();
                return false;
            }

            // Kiểm tra RadioButton có được chọn không
            if (!rdbNam.Checked && !rdbNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }

            // Kiểm tra mã sinh viên có trùng không

            if (sinhVienBLL.IsMaSVExist(txtMSSV.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng chọn mã khác.");
                txtMSSV.Focus();
                return false;
            }

            if (sinhVienBLL.IsCCCDExist(txtCCCD.Text))
            {
                MessageBox.Show("CCCD đã tồn tại. Vui lòng kiểm tra lại.");
                txtCCCD.Focus();
                return false;
            }

            ChuanHoaDuLieu();

            return true;
        }

        private void ChuanHoaDuLieu()
        {
            txtMSSV.Text = txtMSSV.Text.Trim();
            txtCCCD.Text = txtCCCD.Text.Trim();

            string[] words = txtName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i].ToLower());
            }
            txtName.Text = string.Join(" ", words);


            txtDiaChiChiTiet.Text = txtDiaChiChiTiet.Text.Trim();

            cbbTinh.Text = cbbTinh.Text.Trim();
            cbbQuanHuyen.Text = cbbQuanHuyen.Text.Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;
            SinhVienDTO sinhVien = new SinhVienDTO()
            {
                MSSV = txtMSSV.Text,
                CCCD = txtCCCD.Text,
                HoTen = txtName.Text,
                SDT = txtSDT.Text,
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdbNam.Checked ? "nam" : "nữ",
                SoPhong = txtSoPhong.Text,
                UserID = txtMaND.Text,
                Tinh = cbbTinh.Text,
                HuyenTP = cbbQuanHuyen.Text,
                SoNha = txtDiaChiChiTiet.Text,
            };
            sinhVienBLL.AddSinhVien(sinhVien);

            MessageBox.Show("Dữ liệu đã được thêm vào bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }

            sinhVienBLL.DeleteSinhVien(txtMSSV.Text);
            MessageBox.Show("Dữ liệu đã được xóa khỏi bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                return;
            }
            SinhVienDTO sinhVien = new SinhVienDTO()
            {
                MSSV = txtMSSV.Text,
                CCCD = txtCCCD.Text,
                HoTen = txtName.Text,
                SDT = txtSDT.Text,
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdbNam.Checked ? "nam" : "nữ",
                SoPhong = txtSoPhong.Text,
                UserID = txtMaND.Text,
                Tinh = cbbTinh.Text,
                HuyenTP = cbbQuanHuyen.Text,
                SoNha = txtDiaChiChiTiet.Text,
            };

            sinhVienBLL.UpdateSinhVien(sinhVien);
            MessageBox.Show("Dữ liệu đã được cập nhật trong bộ nhớ. Hãy nhấn 'Lưu' để lưu vào cơ sở dữ liệu.");

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtCCCD.Text = "";
            txtDiaChiChiTiet.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
            txtSoPhong.Text = "";
            cbbTinh.SelectedIndex = -1;
            cbbQuanHuyen.SelectedIndex = -1;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }


        private void ptbTim_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mssv", "Thông Báo");
                txtMSSV.Focus();
                return;
            }

            // Lấy dữ liệu sinh viên theo mã sinh viên
            DataTable dtSinhVien = sinhVienBLL.TimSinhVienByMaSV(txtMSSV.Text.Trim());

            // Nếu có dữ liệu trả về
            if (dtSinhVien.Rows.Count > 0)
            {
                DataRow row = dtSinhVien.Rows[0];

                // Đổ dữ liệu vào các TextBox tương ứng
                txtName.Text = row["hoten"].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row["ngaysinh"]);
                txtCCCD.Text = row["cccd"].ToString();
                txtSDT.Text = row["sdt"].ToString();
                txtSoPhong.Text = row["sophong"].ToString();

                string gioiTinh = row["gioitinh"].ToString();
                if (gioiTinh == "nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;

                // Đổ dữ liệu vào địa chỉ
                cbbTinh.Text = row["tinh"].ToString();
                cbbQuanHuyen.Text = row["huyen_tp"].ToString();
                txtDiaChiChiTiet.Text = row["sonha"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên với mã " + txtMSSV.Text);
            }
        
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn hoàn tác không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                sinhVienBLL.Undo();
                MessageBox.Show("Thao tác hoàn tác thành công.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool isSaved = sinhVienBLL.SaveSinhVienData();
            if (isSaved)
            {
                MessageBox.Show("Dữ liệu đã được lưu vào cơ sở dữ liệu!");
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại!");
            }
        }
    }
}
