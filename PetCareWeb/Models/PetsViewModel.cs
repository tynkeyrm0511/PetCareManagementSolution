using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class PetsViewModel
    {
        public int MaKhachHang { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Tên thú cưng")]
        public string TenThuCung { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Loài")]
        public string Loai { get; set; }

        public List<ThuCungViewModel> ThuCungs { get; set; } = new List<ThuCungViewModel>();
    }

    public class ThuCungViewModel
    {
        public int MaThuCung { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Tên thú cưng")]
        public string TenThuCung { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Loài")]
        public string Loai { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnhBase64 { get; set; }
    }
}
