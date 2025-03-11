using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace PetCareAdminApp

{
    public partial class frmKhachHang: Form
    {
        private DatabaseManager quanlyDB = new DatabaseManager();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadKhachHang();
        }
        private void loadKhachHang()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKhachHang.DataSource = dt;
            }
        }
        private void xoaCacTruongThongTin()
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();     
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "INSERT INTO KhachHang (TenKhachHang, " +
                    "SoDienThoai, Email, MatKhau) VALUES (@TenKhachHang, @SoDienThoai, @Email, @MatKhau)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKhachHang", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadKhachHang();
            xoaCacTruongThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "UPDATE KhachHang SET TenKhachHang=@TenKhachHang, " +
                    "SoDienThoai=@SoDienThoai, Email=@Email, MatKhau=@MatKhau " +
                    "WHERE MaKhachHang=@MaKhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenKhachHang", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKhachHang.Text); // Đảm bảo rằng MaKhachHang được lấy đúng cách
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadKhachHang();
            xoaCacTruongThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận xóa
            DialogResult ketQua = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kiểm tra kết quả của hộp thoại xác nhận
            if (ketQua == DialogResult.Yes)
            {
                using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
                {
                    string query = "DELETE FROM KhachHang WHERE MaKhachHang=@MaKhachHang";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKhachHang.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Nạp lại danh sách khách hàng và làm mới các trường thông tin
                loadKhachHang();
                xoaCacTruongThongTin();
            }
            // Nếu người dùng chọn No, không làm gì thêm
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM KhachHang WHERE TenKhachHang LIKE @TuKhoa OR SoDienThoai LIKE @TuKhoa OR Email LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKhachHang.DataSource = dt;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //aaa
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvKhachHang.Rows[e.RowIndex];
                txtMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtTenKhachHang.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadKhachHang();
            xoaCacTruongThongTin();
        }
    }
}
