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

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                if (string.IsNullOrEmpty(picThuCung.ImageLocation))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho thú cưng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "INSERT INTO ThuCung(TenThuCung, Loai, MaKhachHang, HinhAnh) " +
                    "VALUES (@TenThuCung,@Loai,@MaKhachHang,@HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenThuCung", txtTenThuCung.Text);
                cmd.Parameters.AddWithValue("@Loai", cmbLoai.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@MaKhachHang", cmbChu.SelectedValue.ToString());
              
                cmd.Parameters.AddWithValue("@HinhAnh", picThuCung.ImageLocation);

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

                string query = "UPDATE ThuCung SET TenThuCung=@TenThuCung, Loai=@Loai, MaKhachHang=@MaKhachHang, HinhAnh=@HinhAnh WHERE MaThuCung=@MaThuCung";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaThuCung", txtMaThuCung.Text);
                cmd.Parameters.AddWithValue("@TenThuCung", txtTenThuCung.Text);
                cmd.Parameters.AddWithValue("@Loai", cmbLoai.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@MaKhachHang", cmbChu.SelectedValue.ToString());

                cmd.Parameters.AddWithValue("@HinhAnh", picThuCung.ImageLocation);

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
                string hinhAnhPath = row.Cells["HinhAnh"].Value.ToString();
                if (!string.IsNullOrEmpty(hinhAnhPath))
                {
                    picThuCung.Image = Image.FromFile(hinhAnhPath);
                }
                else
                {
                    picThuCung.Image = null;
                }
            }
        }
    }
}
