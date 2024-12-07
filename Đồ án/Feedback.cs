using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmPhanHoi : Form
    {
        private PhanHoiBLL bll= new PhanHoiBLL();
        int tmp = 0;
        public frmPhanHoi()
        {
            InitializeComponent();
            this.TopLevel = false;
            bll.LoadPhanHoi();
        }

        private void frmPhanHoi_Load(object sender, EventArgs e)
        {
            
        }

        private void txtMSSV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Mã số sinh viên không được để trống!");
                return;
            }

            // Gọi BLL để lấy thông tin sinh viên
            var thongTinSinhVien = bll.GetThongTinSinhVien(txtMSSV.Text);

            if (string.IsNullOrEmpty(thongTinSinhVien.HoTen))
            {
                MessageBox.Show("Sinh viên không tồn tại.");
                return;
            }

            // Cập nhật thông tin vào các trường khác trên UI
            txtHoTen.Text = thongTinSinhVien.HoTen;
            txtSDT.Text = thongTinSinhVien.SDT;

        }

        private void btnGuiPhanHoi_Click(object sender, EventArgs e)
        {
            PhanHoiDTO phanhoi = new PhanHoiDTO(txtMSSV.Text, txtHoTen.Text,txtYKien.Text,tmp);
            if(bll.KiemTraDuLieu(phanhoi) != null)
            {
                MessageBox.Show(bll.KiemTraDuLieu(phanhoi));
                return;
            }

            bll.AddPhanHoi(phanhoi);

            MessageBox.Show("Đánh giá đã gửi thành công");

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bll.SavePhanHoi();
                MessageBox.Show("Dữ liệu đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }

        }

        private void frmHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hoàn tác các thay đổi?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bll.UndoChanges(); // Hoàn tác các thay đổi
                MessageBox.Show("Đã hoàn tác các thay đổi.");
            }
        }

        private void ptbRong1_Click(object sender, EventArgs e)
        {
            tmp = 1;
            ptbRong1.Hide();
            ptbRong2.Show();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbRong2_Click(object sender, EventArgs e)
        {
            tmp = 2;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbRong3_Click(object sender, EventArgs e)
        {
            tmp = 3;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Hide();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbRong4_Click(object sender, EventArgs e)
        {
            tmp = 4;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Hide();
            ptbRong4.Hide();
            ptbRong5.Show();
        }

        private void ptbRong5_Click(object sender, EventArgs e)
        {
            tmp = 5;
            ptbRong1.Hide();
            ptbRong2.Hide();
            ptbRong3.Hide();
            ptbRong4.Hide();
            ptbRong5.Hide();
        }

        private void ptbSao1_Click(object sender, EventArgs e)
        {
            tmp = 1;
            ptbSao1.Show();
            ptbRong2.Show();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbSao2_Click(object sender, EventArgs e)
        {
            tmp = 2;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbRong3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbSao3_Click(object sender, EventArgs e)
        {
            tmp = 3;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbSao3.Show();
            ptbRong4.Show();
            ptbRong5.Show();
        }

        private void ptbSao4_Click(object sender, EventArgs e)
        {
            tmp = 4;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbSao3.Show();
            ptbSao4.Show();
            ptbRong5.Show();
        }

        private void ptbSao5_Click(object sender, EventArgs e)
        {
            tmp = 1;
            ptbSao1.Show();
            ptbSao2.Show();
            ptbSao3.Show();
            ptbSao4.Show();
            ptbSao5.Show();
        }

        
    }
}
