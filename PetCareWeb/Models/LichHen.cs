using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class LichHen
    {
        [Key]
        public int MaLichHen { get; set; }

        [Required]
        [Display(Name = "Ngày Hẹn")]
        [DataType(DataType.Date)]
        public DateTime NgayHen { get; set; }

        [Required]
        [ForeignKey("KhachHang")]
        public int MaKhachHang { get; set; }
        public KhachHang KhachHang { get; set; }

        [Required]
        [ForeignKey("ThuCung")]
        public int MaThuCung { get; set; }
        public ThuCung ThuCung { get; set; }

        [Required]
        [ForeignKey("DichVu")]
        public int MaDichVu { get; set; }
        public DichVu DichVu { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [Required]
        [Display(Name = "Giờ Hẹn")]
        [DataType(DataType.Time)]
        public TimeSpan GioHen { get; set; }
    }
}
