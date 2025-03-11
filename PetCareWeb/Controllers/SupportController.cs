using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetCareWeb.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
