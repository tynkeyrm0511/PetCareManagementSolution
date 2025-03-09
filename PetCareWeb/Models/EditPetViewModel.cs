using Microsoft.AspNetCore.Mvc;

namespace PetCareWeb.Models
{
    public class EditPetViewModel
    {
        public int MaThuCung { get; set; }
        public string TenThuCung { get; set; }
        public string Loai { get; set; }
    }
}
