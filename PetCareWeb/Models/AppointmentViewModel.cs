using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class AppointmentViewModel
    {
        public int MaLichHen { get; set; }

        [Required]
        [Display(Name = "Ngày Hẹn")]
        [DataType(DataType.Date)]
        public DateTime NgayHen { get; set; }

        [Display(Name = "Tên Thú Cưng")]
        public string TenThuCung { get; set; }

        [Display(Name = "Tên Dịch Vụ")]
        public string TenDichVu { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [Required]
        [Display(Name = "Giờ Hẹn")]
        [DataType(DataType.Time)]
        public TimeSpan GioHen { get; set; }
    }
}
