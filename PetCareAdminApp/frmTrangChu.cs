using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetCareAdminApp
{
    public partial class frmTrangChu: Form
    {
        private bool isClosing = false;

        public frmTrangChu()
        {
            InitializeComponent();
            timerThoiGian.Start();
        }

        private void OpenChildForm(Form childForm)
        {
            // Xóa các control hiện có trong panelMain
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls[0].Dispose();
            }

            // Thiết lập form con
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.Show();
        }


        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                DialogResult ketQua = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (ketQua == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    // Đặt biến cờ là true để ngăn việc hiển thị hộp thoại xác nhận thêm lần nữa
                    isClosing = true;
                    Application.Exit();
                }
            }
        }
        private void btnMoFormKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void btnMoFormThuCung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThuCung());
        }

        private void btnMoFormDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDichVu());
        }

        private void btnMoFormLichHen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichHen());
        }

        private void btnMoFormChat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChat());
        }

        private void timerThoiGian_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelMain.Controls)
            {
                if (control is Form)
                {
                    Form childForm = (Form)control;
                    childForm.Close();
                }
            }
        }
    }
}
