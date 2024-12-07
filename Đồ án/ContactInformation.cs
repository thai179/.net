using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace Đồ_án
{
    public partial class frmQLTTLienLac : Form
    {
        public frmQLTTLienLac()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void frmQLTTLienLac_Load(object sender, EventArgs e)
        {
            dgvThanNhan.DataSource = ThanNhanBLL.GetAllThanNhan();
            dgvThanNhan.Columns["masv"].HeaderText = "Mã Số SV";
            dgvThanNhan.Columns["hoten"].HeaderText = "Họ tên";
            dgvThanNhan.Columns["moiquanhe"].HeaderText = "Mối quan hệ";
            dgvThanNhan.Columns["sdt"].HeaderText = "Số điện thoại";
        }
        private void ChuanHoaHoTen()
        {
            // Chuẩn hóa họ tên: Xóa khoảng trắng thừa và viết hoa chữ cái đầu
            txtTenTN.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtTenTN.Text.Trim().ToLower());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ThanNhanBLL.CheckStudentExist(txtMSSV.Text))
            {
                MessageBox.Show("Mã sinh viên không tồn tại. Hãy thêm sinh viên trước", "Thông báo");
                return;
            }
            string tmp = ThanNhanBLL.ValidateThanNhanData(txtMSSV.Text, txtTenTN.Text, cbbQuanHe.Text, txtSDTTN.Text);
            if (tmp != null)
            {
                MessageBox.Show(tmp, "Thông báo");
                return;
            }

            ThanNhanDTO newThanNhan = new ThanNhanDTO
            {
                Masv = txtMSSV.Text,
                Hoten = txtTenTN.Text,
                Moiquanhe = cbbQuanHe.Text,
                Sdt = txtSDTTN.Text
            };

            if (ThanNhanBLL.AddThanNhan(newThanNhan))
            {
                MessageBox.Show("Dữ liệu đã được thêm vào cơ sở dữ liệu.");
                Refresh();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm dữ liệu.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThanNhan.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvThanNhan.SelectedRows[0];
                int matn = Convert.ToInt32(row.Cells["matn"].Value);

                if (ThanNhanBLL.DeleteThanNhan(matn))
                {
                    MessageBox.Show("Dữ liệu đã được xóa.");
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThanNhan.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvThanNhan.SelectedRows[0];
                int matn = Convert.ToInt32(row.Cells["matn"].Value);

                ThanNhanDTO updatedThanNhan = new ThanNhanDTO
                {
                    Matn = matn,
                    Masv = txtMSSV.Text,
                    Hoten = txtTenTN.Text,
                    Moiquanhe = cbbQuanHe.Text,
                    Sdt = txtSDTTN.Text
                };

                if (ThanNhanBLL.UpdateThanNhan(updatedThanNhan))
                {
                    MessageBox.Show("Dữ liệu đã được cập nhật.");
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật dữ liệu.");
                }
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hoàn tác không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ThanNhanBLL.UndoChanges();
                dgvThanNhan.DataSource = ThanNhanBLL.GetAllThanNhan();
                MessageBox.Show("Hoàn tác thành công!", "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ThanNhanBLL.SaveChanges())
            {
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.frmQLTTLienLac_Load(sender,e);
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvThanNhan.DataSource = ThanNhanBLL.Refresh();
        }

        private void txtTenTN_Leave(object sender, EventArgs e)
        {
            ChuanHoaHoTen();
        }
    }
}
