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
using System.IO;
using System.Drawing.Imaging;

namespace PetCareAdminApp
{
    public partial class frmThuCung: Form
    {
        private DatabaseManager quanlyDB = new DatabaseManager();
        public frmThuCung()
        {
            InitializeComponent();
        }

        private void frmThuCung_Load(object sender, EventArgs e)
        {
            loadChu();
            loadThuCung();
            LoadLoaiThuCung();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dgvThuCung.AutoGenerateColumns = false;

            // Xóa tất cả các cột hiện có trong DataGridView
            dgvThuCung.Columns.Clear();

            // Thêm cột MaThuCung
            DataGridViewTextBoxColumn maThuCungColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Thú Cưng",
                DataPropertyName = "MaThuCung",
                Name = "MaThuCung"
            };
            dgvThuCung.Columns.Add(maThuCungColumn);

            // Thêm cột TenThuCung
            DataGridViewTextBoxColumn tenThuCungColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Thú Cưng",
                DataPropertyName = "TenThuCung",
                Name = "TenThuCung"
            };
            dgvThuCung.Columns.Add(tenThuCungColumn);

            // Thêm cột Loai
            DataGridViewTextBoxColumn loaiColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại",
                DataPropertyName = "Loai",
                Name = "Loai"
            };
            dgvThuCung.Columns.Add(loaiColumn);

            // Thêm cột MaKhachHang
            DataGridViewTextBoxColumn maKhachHangColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Khách Hàng",
                DataPropertyName = "MaKhachHang",
                Name = "MaKhachHang"
            };
            dgvThuCung.Columns.Add(maKhachHangColumn);

            // Thêm cột HinhAnhBase64
            DataGridViewTextBoxColumn hinhAnhBase64Column = new DataGridViewTextBoxColumn
            {
                HeaderText = "Hình Ảnh Base64",
                DataPropertyName = "HinhAnhBase64",
                Name = "HinhAnhBase64"
            };
            dgvThuCung.Columns.Add(hinhAnhBase64Column);
        }
        private void xoaCacTruongThongTin()
        {
            txtMaThuCung.Clear();
            txtTenThuCung.Clear();
            cmbLoai.SelectedIndex = -1;
            cmbChu.SelectedIndex = -1;
            picThuCung.Image = null;
        }
        private void loadThuCung()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM ThuCung";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvThuCung.DataSource = dt;
            }
        }
        private void loadChu()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT MaKhachHang, TenKhachHang FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbChu.DataSource = dt;
                cmbChu.DisplayMember = "TenKhachHang";
                cmbChu.ValueMember = "MaKhachHang";
            }
        }
        private void LoadLoaiThuCung()
        {
            cmbLoai.Items.Add("Chó");
            cmbLoai.Items.Add("Mèo");
            cmbLoai.Items.Add("Chim");
            cmbLoai.Items.Add("Thỏ");
            cmbLoai.Items.Add("Chuột");
            cmbLoai.Items.Add("Sóc");
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
                    picThuCung.Image = Image.FromFile(selectedImagePath);
                    picThuCung.ImageLocation = selectedImagePath; // Cập nhật ImageLocation
                }
            }
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
                if (string.IsNullOrEmpty(picThuCung.ImageLocation))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho thú cưng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng ảnh để mã hóa đúng
                ImageFormat format;
                if (Path.GetExtension(picThuCung.ImageLocation).ToLower() == ".png")
                {
                    format = System.Drawing.Imaging.ImageFormat.Png;
                }
                else
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }

                // Chuyển đổi ảnh thành chuỗi Base64
                string base64String = ImageToBase64(picThuCung.Image, format);

                string query = "INSERT INTO ThuCung(TenThuCung, Loai, MaKhachHang, HinhAnhBase64) " +
                    "VALUES (@TenThuCung,@Loai,@MaKhachHang,@HinhAnhBase64)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThuCung", txtTenThuCung.Text);
                cmd.Parameters.AddWithValue("@Loai", cmbLoai.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@MaKhachHang", cmbChu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@HinhAnhBase64", base64String);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadThuCung();
            xoaCacTruongThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                if (string.IsNullOrEmpty(picThuCung.ImageLocation))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho thú cưng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng ảnh để mã hóa đúng
                ImageFormat format;
                if (Path.GetExtension(picThuCung.ImageLocation).ToLower() == ".png")
                {
                    format = System.Drawing.Imaging.ImageFormat.Png;
                }
                else
                {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                }

                // Chuyển đổi ảnh thành chuỗi Base64
                string base64String = ImageToBase64(picThuCung.Image, format);

                string query = "UPDATE ThuCung SET TenThuCung=@TenThuCung, Loai=@Loai, MaKhachHang=@MaKhachHang, HinhAnhBase64=@HinhAnhBase64 WHERE MaThuCung=@MaThuCung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuCung", txtMaThuCung.Text);
                cmd.Parameters.AddWithValue("@TenThuCung", txtTenThuCung.Text);
                cmd.Parameters.AddWithValue("@Loai", cmbLoai.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@MaKhachHang", cmbChu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@HinhAnhBase64", base64String);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadThuCung();
            xoaCacTruongThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận xóa
            DialogResult ketQua = MessageBox.Show("Bạn có chắc chắn muốn xóa thú cưng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kiểm tra kết quả của hộp thoại xác nhận
            if (ketQua == DialogResult.Yes)
            {
                using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
                {
                    string query = "DELETE FROM ThuCung WHERE MaThuCung=@MaThuCung";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaThuCung", txtMaThuCung.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Nạp lại danh sách thú cưng và làm mới các trường thông tin
                loadThuCung();
                xoaCacTruongThongTin();
            }
            // Nếu người dùng chọn No, không làm gì thêm
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM ThuCung WHERE TenThuCung LIKE @TuKhoa OR Loai LIKE @TuKhoa OR MaKhachHang IN (SELECT MaKhachHang FROM KhachHang WHERE TenKhachHang LIKE @TuKhoa)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvThuCung.DataSource = dt;
            }
        }

        private void dgvThuCung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvThuCung.Rows[e.RowIndex];
                txtMaThuCung.Text = row.Cells["MaThuCung"].Value.ToString();
                txtTenThuCung.Text = row.Cells["TenThuCung"].Value.ToString();
                cmbLoai.SelectedItem = row.Cells["Loai"].Value.ToString();
                cmbChu.SelectedValue = row.Cells["MaKhachHang"].Value.ToString();
                string base64String = row.Cells["HinhAnhBase64"].Value.ToString();
                if (!string.IsNullOrEmpty(base64String))
                {
                    picThuCung.Image = Base64ToImage(base64String);
                }
                else
                {
                    picThuCung.Image = null;
                }
            }
        }
    }
}
