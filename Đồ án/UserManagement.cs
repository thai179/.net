using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Đồ_án
{
    public partial class frmQLNguoiDung : Form
    {
        private NguoiDungBLL nguoiDungBLL;
        public frmQLNguoiDung()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void frmQLNguoiDung_Load(object sender, EventArgs e)
        {
            nguoiDungBLL = new NguoiDungBLL();
            nguoiDungBLL.LoadND();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaND.Text = "";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtMatKhau.Text = "";
            cbbQuyenHan.SelectedIndex = -1;
            cbbQuanHuyen.SelectedIndex = -1;
            cbbTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private bool KiemTraTTConTrol()
        {
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng.");
                txtMaND.Focus();
                return false;
            }

            if (txtMaND.Text.Contains(" "))
            {
                MessageBox.Show("Mã người dùng không được chứa khoảng trắng.");
                txtMaND.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                txtMatKhau.Focus();
                return false;
            }

            if (txtMatKhau.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng.");
                txtMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                txtHoTen.Focus();
                return false;
            }

            txtHoTen.Text = nguoiDungBLL.ChuanHoaTen(txtHoTen.Text);

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
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

            if (string.IsNullOrEmpty(cbbQuyenHan.Text))
            {
                MessageBox.Show("Vui lòng chọn quyền hạn.");
                cbbQuyenHan.Focus();
                return false;
            }

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

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.");
                txtDiaChi.Focus();
                return false;
            }


            return true;
        }
        private bool KiemTraMaND(string maND)
        {
            try
            {
                // Gọi BLL để kiểm tra mã người dùng
                bool isExist = nguoiDungBLL.KiemTraMaNguoiDung(maND);

                if (isExist)
                {
                    MessageBox.Show("Mã người dùng đã tồn tại. Vui lòng chọn mã khác.", "Thông Báo");
                    txtMaND.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi trong quá trình kiểm tra
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo");
                return false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraTTConTrol() == false)
                return;
            if(KiemTraMaND(txtMaND.Text))
                return;
            string matKhauMaHoa = nguoiDungBLL.MaHoaMatKhau(txtMatKhau.Text);

            NguoiDungDTO nguoiDungDTO = new NguoiDungDTO
            {
                MaND = txtMaND.Text,
                MatKhau = matKhauMaHoa,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Value,
                SDT = txtSDT.Text,
                ChucVu = cbbQuyenHan.Text,
                Tinh = cbbTinh.Text,
                HuyenTP = cbbQuanHuyen.Text,
                SoNha = txtDiaChi.Text
            };
            nguoiDungBLL.ThemNguoiDung(nguoiDungDTO);

            MessageBox.Show("Dữ liệu đã được lưu vào DataSet.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaND.Text))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng.");
                txtMaND.Focus();
                return;
            }
            nguoiDungBLL.XoaNguoiDung(txtMaND.Text);
            MessageBox.Show("Dữ liệu đã được xóa khỏi DataSet.");
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if(KiemTraTTConTrol() == false)
                return;
            string matKhauMaHoa = nguoiDungBLL.MaHoaMatKhau(txtMatKhau.Text);
            NguoiDungDTO nguoiDungDTO = new NguoiDungDTO
            {
                MaND = txtMaND.Text,
                MatKhau = matKhauMaHoa,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Value,
                SDT = txtSDT.Text,
                ChucVu = cbbQuyenHan.Text,
                Tinh = cbbTinh.Text,
                HuyenTP = cbbQuanHuyen.Text,
                SoNha = txtDiaChi.Text
            };

            MessageBox.Show("Thông tin người dùng đã được cập nhật vào DataSet.");
                
        }

        private void ptbTim_Click(object sender, EventArgs e)
        {
            string maND = txtMaND.Text;  // Lấy mã người dùng từ TextBox

            if (string.IsNullOrEmpty(maND))
            {
                MessageBox.Show("Vui lòng nhập mã người dùng", "Thông Báo");
                txtMaND.Focus();
                return;
            }

            try
            {
                // Gọi BLL để lấy dữ liệu người dùng
                DataTable userData = nguoiDungBLL.TimKiemNguoiDung(maND);

                if (userData.Rows.Count > 0)
                {
                    // Lấy thông tin từ DataTable và điền vào các TextBox
                    DataRow row = userData.Rows[0];  // Chỉ có một người dùng trong kết quả

                    txtHoTen.Text = row["hoten"].ToString();
                    txtMatKhau.Text = row["matkhau"].ToString();
                    dtpNgaySinh.Value = Convert.ToDateTime(row["ngaysinh"]);
                    cbbQuyenHan.Text = row["chucvu"].ToString();
                    txtSDT.Text = row["sdt"].ToString();
                    cbbTinh.Text = row["tinh"].ToString();
                    cbbQuanHuyen.Text = row["huyen_tp"].ToString();
                    txtDiaChi.Text = row["sonha"].ToString();
                }
                else
                {
                    MessageBox.Show("Mã người dùng không tồn tại", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi gọi BLL
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo");
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn muốn hoàn tác không","Thông báo",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                nguoiDungBLL.Undo();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi BLL để lưu thông tin người dùng
                bool isSuccess = nguoiDungBLL.LuuThongTinNguoiDung();

                if (isSuccess)
                {
                    MessageBox.Show("Thông tin đã được lưu thành công.");
                }
                else
                {
                    MessageBox.Show("Lưu thông tin không thành công.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có (thông báo lỗi cho người dùng)
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message);
            }
        }

    }
}
