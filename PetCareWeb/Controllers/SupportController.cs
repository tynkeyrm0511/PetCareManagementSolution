using Microsoft.AspNetCore.Mvc;

namespace PetCareWeb.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
