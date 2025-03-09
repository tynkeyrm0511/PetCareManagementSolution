using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetCareWeb.Controllers
{
    public class AppointmentController : Controller
    {
        [HttpPost]
        public IActionResult Book(int dichVuId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Message"] = "Vui lòng đăng nhập để đặt lịch hẹn.";
                return RedirectToAction("Index", "Home");
            }

            // Logic để chuyển hướng tới trang đặt lịch hẹn nếu đã đăng nhập
            return RedirectToAction("BookAppointment", new { id = dichVuId });
        }

        [Authorize]
        public IActionResult BookAppointment(int id)
        {
            // Lấy thông tin dịch vụ từ CSDL và hiển thị trang đặt lịch hẹn
            // Logic cho trang đặt lịch hẹn (nếu cần thiết)
            return View();
        }
    }
}
