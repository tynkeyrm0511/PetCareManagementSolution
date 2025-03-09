using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Tên khách hàng")]
        public string TenKhachHang { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "{0} và {1} không khớp.")]
        public string ConfirmMatKhau { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }
    }
}
