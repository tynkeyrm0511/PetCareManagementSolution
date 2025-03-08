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
        public frmTrangChu()
        {
            InitializeComponent();
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

        }
        private void btnMoFormKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void btnMoFormThuCung_Click(object sender, EventArgs e)
        {

        }

        private void btnMoFormDichVu_Click(object sender, EventArgs e)
        {

        }

        private void btnMoFormLichHen_Click(object sender, EventArgs e)
        {

        }

        private void btnMoFormChat_Click(object sender, EventArgs e)
        {

        }
    }
}
