using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace PetCareAdminApp
{
    public partial class frmDangNhap: Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["PetCareDB"].ConnectionString;
        private bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM QuanTriVien WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    conn.Open();

                    // ExecuteScalar trả về object, cần chuyển đổi về int
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây nếu cần, hoặc ném ngoại lệ để xử lý tiếp bên trên
                throw new Exception("Lỗi khi kiểm tra thông tin đăng nhập: " + ex.Message);
            }
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            try
            {
                if (KiemTraDangNhap(tenDangNhap, matKhau))
                {
                    frmTrangChu frmTrangChu = new frmTrangChu();
                    frmTrangChu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập", 
                        "Lỗi đăng nhập", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
