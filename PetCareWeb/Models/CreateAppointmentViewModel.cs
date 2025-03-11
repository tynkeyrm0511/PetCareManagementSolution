using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class CreateAppointmentViewModel
    {
        [Required]
        [Display(Name = "Ngày Hẹn")]
        [DataType(DataType.Date)]
        public DateTime NgayHen { get; set; }

        [Required]
        public int MaThuCung { get; set; }

        [Required]
        public int MaDichVu { get; set; }

        [Required]
        [Display(Name = "Giờ Hẹn")]
        [DataType(DataType.Time)]
        public TimeSpan GioHen { get; set; }

        public List<ThuCung> ThuCungs { get; set; } = new List<ThuCung>();
        public List<DichVu> DichVus { get; set; } = new List<DichVu>();
    }
}
