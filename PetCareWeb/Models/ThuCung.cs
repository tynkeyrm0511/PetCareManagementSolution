using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareWeb.Models
{
    public class ThuCung
    {
        [Key]
        public int MaThuCung { get; set; }

        [Required]
        [Display(Name = "Tên thú cưng")]
        public string TenThuCung { get; set; }

        [Required]
        [Display(Name = "Loài")]
        public string Loai { get; set; }

        [Required]
        public int MaKhachHang { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnhBase64 { get; set; }

        [ForeignKey("MaKhachHang")]
        public virtual KhachHang KhachHang { get; set; }
    }
}
