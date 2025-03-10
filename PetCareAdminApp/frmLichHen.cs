using Microsoft.Data.SqlClient;
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
    public partial class frmLichHen: Form
    {
        private DatabaseManager quanlyDB = new DatabaseManager();
        public frmLichHen()
        {
            InitializeComponent();
        }

        private void frmLichHen_Load(object sender, EventArgs e)
        {
            loadLichHen();
            loadKhachHang();
            loadThuCung();
            loadDichVu();
            loadTrangThai();
            loadGioHen();
        }
        private void loadLichHen()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT * FROM LichHen";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvLichHen.DataSource = dt;
            }
        }
        private void loadKhachHang()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT MaKhachHang, TenKhachHang FROM KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbKhachHang.DataSource = dt;
                cmbKhachHang.DisplayMember = "TenKhachHang";
                cmbKhachHang.ValueMember = "MaKhachHang";
            }
        }

        private void loadThuCung()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT MaThuCung, TenThuCung FROM ThuCung";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbThuCung.DataSource = dt;
                cmbThuCung.DisplayMember = "TenThuCung";
                cmbThuCung.ValueMember = "MaThuCung";
            }
        }

        private void loadDichVu()
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT MaDichVu, TenDichVu FROM DichVu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbDichVu.DataSource = dt;
                cmbDichVu.DisplayMember = "TenDichVu";
                cmbDichVu.ValueMember = "MaDichVu";
            }
        }

        private void loadTrangThai()
        {
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("Đang chờ duyệt");
            cmbTrangThai.Items.Add("Đã duyệt");
            cmbTrangThai.Items.Add("Đã từ chối");
        }


        private void loadGioHen()
        {
            cmbGioHen.Items.Clear();
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30) // Bạn có thể thay đổi khoảng cách thời gian nếu muốn
                {
                    TimeSpan time = new TimeSpan(hour, minute, 0);
                    cmbGioHen.Items.Add(time.ToString(@"hh\:mm"));
                }
            }
        }
        private void loadThuCungTheoKhachHang(string maKhachHang)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "SELECT MaThuCung, TenThuCung FROM ThuCung WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbThuCung.DataSource = dt;
                cmbThuCung.DisplayMember = "TenThuCung";
                cmbThuCung.ValueMember = "MaThuCung";
            }
        }

        private void xoaCacTruongThongTin()
        {
            txtMaLichHen.Clear();
            dtpNgayHen.Value = DateTime.Now;
            cmbGioHen.SelectedIndex = -1;
            cmbKhachHang.SelectedIndex = -1;
            cmbThuCung.SelectedIndex = -1;
            cmbDichVu.SelectedIndex = -1;
            cmbTrangThai.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "INSERT INTO LichHen (NgayHen, GioHen, MaKhachHang, MaThuCung, MaDichVu, TrangThai) VALUES (@NgayHen, @GioHen, @MaKhachHang, @MaThuCung, @MaDichVu, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayHen", dtpNgayHen.Value);
                cmd.Parameters.AddWithValue("@GioHen", TimeSpan.Parse(cmbGioHen.SelectedItem.ToString()));
                cmd.Parameters.AddWithValue("@MaKhachHang", cmbKhachHang.SelectedValue);
                cmd.Parameters.AddWithValue("@MaThuCung", cmbThuCung.SelectedValue);
                cmd.Parameters.AddWithValue("@MaDichVu", cmbDichVu.SelectedValue);
                cmd.Parameters.AddWithValue("@TrangThai", cmbTrangThai.SelectedItem.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadLichHen();
            xoaCacTruongThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = "UPDATE LichHen SET NgayHen=@NgayHen, GioHen=@GioHen, MaKhachHang=@MaKhachHang, MaThuCung=@MaThuCung, MaDichVu=@MaDichVu, TrangThai=@TrangThai WHERE MaLichHen=@MaLichHen";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLichHen", txtMaLichHen.Text);
                cmd.Parameters.AddWithValue("@NgayHen", dtpNgayHen.Value);
                cmd.Parameters.AddWithValue("@GioHen", TimeSpan.Parse(cmbGioHen.SelectedItem.ToString()));
                cmd.Parameters.AddWithValue("@MaKhachHang", cmbKhachHang.SelectedValue);
                cmd.Parameters.AddWithValue("@MaThuCung", cmbThuCung.SelectedValue);
                cmd.Parameters.AddWithValue("@MaDichVu", cmbDichVu.SelectedValue);
                cmd.Parameters.AddWithValue("@TrangThai", cmbTrangThai.SelectedItem.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            loadLichHen();
            xoaCacTruongThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận xóa
            DialogResult ketQua = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch hẹn này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kiểm tra kết quả của hộp thoại xác nhận
            if (ketQua == DialogResult.Yes)
            {
                using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
                {
                    string query = "DELETE FROM LichHen WHERE MaLichHen=@MaLichHen";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLichHen", txtMaLichHen.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Nạp lại danh sách lịch hẹn và làm mới các trường thông tin
                loadLichHen();
                xoaCacTruongThongTin();
            }
        }

        private void dgvLichHen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvLichHen.Rows[e.RowIndex];
                txtMaLichHen.Text = row.Cells["MaLichHen"].Value.ToString();
                dtpNgayHen.Value = Convert.ToDateTime(row.Cells["NgayHen"].Value);
                cmbGioHen.SelectedItem = TimeSpan.Parse(row.Cells["GioHen"].Value.ToString()).ToString(@"hh\:mm");
                cmbKhachHang.SelectedValue = row.Cells["MaKhachHang"].Value;
                cmbThuCung.SelectedValue = row.Cells["MaThuCung"].Value;
                cmbDichVu.SelectedValue = row.Cells["MaDichVu"].Value;
                cmbTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhachHang.SelectedValue != null && cmbKhachHang.SelectedValue is DataRowView)
            {
                string maKhachHang = (cmbKhachHang.SelectedValue as DataRowView)["MaKhachHang"].ToString();
                loadThuCungTheoKhachHang(maKhachHang);
            }
            else if (cmbKhachHang.SelectedValue != null)
            {
                string maKhachHang = cmbKhachHang.SelectedValue.ToString();
                loadThuCungTheoKhachHang(maKhachHang);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            using (SqlConnection conn = quanlyDB.layChuoiKetNoi())
            {
                string query = @"
            SELECT lh.*
            FROM LichHen lh
            JOIN KhachHang kh ON lh.MaKhachHang = kh.MaKhachHang
            JOIN ThuCung tc ON lh.MaThuCung = tc.MaThuCung
            WHERE kh.TenKhachHang LIKE @TuKhoa 
            OR tc.TenThuCung LIKE @TuKhoa";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvLichHen.DataSource = dt;
            }
        }
    }
}
