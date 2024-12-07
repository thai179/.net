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
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class frmBaoTri : Form
    {
        private YeuCauBaoTriBLL bll = new YeuCauBaoTriBLL();
        public frmBaoTri()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
           
            YeuCauBaoTriDTO yeuCau = new YeuCauBaoTriDTO
            {
                SoPhong = txtSoPhong.Text,
                MoTaVanDe = txtMoTaVanDe.Text,
                DoUuTien = cbbDoUuTien.Text
            };
            string tmp = bll.KiemTraThongTin(yeuCau);
            if (tmp != null)
            {
                MessageBox.Show(tmp, "Thông báo");
                return;
            }

            try
            {
                // Gọi BLL để gửi yêu cầu bảo trì
                bll.GuiYeuCau(yeuCau);
                MessageBox.Show("Đã gửi yêu cầu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                txtMoTaVanDe.Text = "";
                txtSoPhong.Text = "";
                cbbDoUuTien.SelectedIndex = 0;
                this.Hide();
            }
        }
    }
}
