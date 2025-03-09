using System.ComponentModel.DataAnnotations;

namespace PetCareWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
    }
}
