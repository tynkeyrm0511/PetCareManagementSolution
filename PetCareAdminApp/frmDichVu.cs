using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace PetCareAdminApp
{
    public partial class frmDichVu: Form
    {
        private DatabaseManager quanlyDB = new DatabaseManager();
        public frmDichVu()
        {
            InitializeComponent();
        }
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            loadDichVu();
        }
        private void loadDichVu()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM DichVu";
                SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDichVu.DataSource = dt;
            }
        }
        private void xoaCacTruongThongTin()
        {
            txtMaDichVu.Clear();
            txtTenDichVu.Clear();
            txtMoTa.Clear();
            txtGia.Clear();
        }
        private string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Chuyển đổi ảnh thành mảng byte
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Chuyển đổi mảng byte thành chuỗi Base64
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        private Image Base64ToImage(string base64String)
        {
            // Chuyển đổi chuỗi Base64 thành mảng byte
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                // Chuyển đổi mảng byte thành ảnh
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                if (string.IsNullOrEmpty(picDichVu.ImageLocation))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng ảnh để mã hóa đúng
                ImageFormat format;
                if (Path.GetExtension(picDichVu.ImageLocation).ToLower() == ".png")
                {
                    format = System.Drawing.Imaging.ImageFormat.Png;
                }
                else
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }

                // Chuyển đổi ảnh thành chuỗi Base64
                string base64String = ImageToBase64(picDichVu.Image, format);

                string query = "INSERT INTO DichVu (TenDichVu, MoTa, Gia, HinhAnhBase64) VALUES (@TenDichVu, @MoTa, @Gia, @HinhAnhBase64)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@Gia", txtGia.Text);
                cmd.Parameters.AddWithValue("@HinhAnhBase64", base64String);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadDichVu();
            xoaCacTruongThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                if (string.IsNullOrEmpty(picDichVu.ImageLocation))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng ảnh để mã hóa đúng
                ImageFormat format;
                if (Path.GetExtension(picDichVu.ImageLocation).ToLower() == ".png")
                {
                    format = System.Drawing.Imaging.ImageFormat.Png;
                }
                else
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }

                // Chuyển đổi ảnh thành chuỗi Base64
                string base64String = ImageToBase64(picDichVu.Image, format);

                string query = "UPDATE DichVu SET TenDichVu=@TenDichVu, MoTa=@MoTa, Gia=@Gia, HinhAnhBase64=@HinhAnhBase64 WHERE MaDichVu=@MaDichVu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDichVu", txtMaDichVu.Text);
                cmd.Parameters.AddWithValue("@TenDichVu", txtTenDichVu.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@Gia", txtGia.Text);
                cmd.Parameters.AddWithValue("@HinhAnhBase64", base64String);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadDichVu();
            xoaCacTruongThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận xóa
            DialogResult ketQua = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kiểm tra kết quả của hộp thoại xác nhận
            if (ketQua == DialogResult.Yes)
            {
                using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
                {
                    string query = "DELETE FROM DichVu WHERE MaDichVu=@MaDichVu";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDichVu", txtMaDichVu.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Nạp lại danh sách dịch vụ và làm mới các trường thông tin
                loadDichVu();
                xoaCacTruongThongTin();
            }
            // Nếu người dùng chọn No, không làm gì thêm
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM DichVu WHERE TenDichVu LIKE @TuKhoa OR MoTa LIKE @TuKhoa OR Gia LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDichVu.DataSource = dt;
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    picDichVu.Image = Image.FromFile(selectedImagePath);
                    picDichVu.ImageLocation = selectedImagePath; // Cập nhật ImageLocation
                }
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDichVu.Rows[e.RowIndex];
                txtMaDichVu.Text = row.Cells["MaDichVu"].Value.ToString();
                txtTenDichVu.Text = row.Cells["TenDichVu"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
                string base64String = row.Cells["HinhAnhBase64"].Value.ToString();
                if (!string.IsNullOrEmpty(base64String))
                {
                    picDichVu.Image = Base64ToImage(base64String);
                }
                else
                {
                    picDichVu.Image = null;
                }
            }
        }
    }
}
