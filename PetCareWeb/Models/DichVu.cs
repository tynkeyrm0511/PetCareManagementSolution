using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCareWeb.Models
{
    [Table("DichVu")]
    public class DichVu
    {
        [Key]
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
        public string HinhAnhBase64 { get; set; }
    }
}
