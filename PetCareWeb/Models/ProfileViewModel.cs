using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class ProfileViewModel
    {
        public int MaKhachHang { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Tên khách hàng")]
        public string TenKhachHang { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string MatKhauMoi { get; set; }
    }

    
}
