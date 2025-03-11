using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PetCareWeb.Data;
using PetCareWeb.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareWeb.Data;
using PetCareWeb.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PetCareWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var khachHang = new KhachHang
                {
                    TenKhachHang = model.TenKhachHang,
                    Email = model.Email,
                    MatKhau = model.MatKhau, // Bạn có thể cần mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                    SoDienThoai = model.SoDienThoai
                };

                _context.KhachHang.Add(khachHang); // Sử dụng DbSet KhachHang
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        // GET: Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.Email == model.Email && kh.MatKhau == model.MatKhau);

                if (khachHang != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, khachHang.TenKhachHang),
                new Claim(ClaimTypes.Email, khachHang.Email),
                new Claim("MaKhachHang", khachHang.MaKhachHang.ToString()) // Thêm MaKhachHang vào claims
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(returnUrl);
                }
                else
                {
                    ViewData["ErrorMessage"] = "Thông tin đăng nhập không chính xác.";
                }
            }

            return View(model);
        }

        // GET: Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["LogoutMessage"] = "Bạn đã đăng xuất thành công.";
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Profile
        public IActionResult Profile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.Email == email);

            if (khachHang == null)
            {
                return NotFound();
            }

            var model = new ProfileViewModel
            {
                MaKhachHang = khachHang.MaKhachHang,
                TenKhachHang = khachHang.TenKhachHang,
                SoDienThoai = khachHang.SoDienThoai,
                Email = khachHang.Email
            };

            return View(model);
        }


        // POST: Account/Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                ViewData["ProfileErrors"] = errorMessages;
                TempData["ProfileMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các trường thông tin.";
                return View(model);
            }

            var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.MaKhachHang == model.MaKhachHang);

            if (khachHang == null)
            {
                TempData["ProfileMessage"] = "Không tìm thấy khách hàng. Vui lòng đăng nhập lại.";
                return View(model);
            }

            khachHang.TenKhachHang = model.TenKhachHang;
            khachHang.SoDienThoai = model.SoDienThoai;

            if (!string.IsNullOrEmpty(model.MatKhauMoi))
            {
                khachHang.MatKhau = model.MatKhauMoi; // Bạn có thể mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
            }

            _context.SaveChanges();

            TempData["ProfileMessage"] = "Thông tin cá nhân đã được cập nhật thành công.";
            return RedirectToAction("Profile");
        }
        // GET: Account/Pets
        public IActionResult Pets()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.Email == email);

            if (khachHang == null)
            {
                return NotFound();
            }

            var thuCung = _context.ThuCung.Where(tc => tc.MaKhachHang == khachHang.MaKhachHang).ToList();

            var model = new PetsViewModel
            {
                MaKhachHang = khachHang.MaKhachHang,
                ThuCungs = thuCung.Select(tc => new ThuCungViewModel
                {
                    MaThuCung = tc.MaThuCung,
                    TenThuCung = tc.TenThuCung,
                    Loai = tc.Loai,
                    HinhAnhBase64 = tc.HinhAnhBase64
                }).ToList()
            };

            return View(model);
        }

        // POST: Account/AddPet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPet(PetsViewModel model, IFormFile hinhAnhThuCung)
        {
            if (ModelState.IsValid)
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.Email == email);

                if (khachHang == null)
                {
                    TempData["PetsMessage"] = "Không tìm thấy khách hàng. Vui lòng đăng nhập lại.";
                    return View("Pets", model);
                }

                var thuCung = new ThuCung
                {
                    TenThuCung = model.TenThuCung,
                    Loai = model.Loai,
                    MaKhachHang = khachHang.MaKhachHang
                };

                if (hinhAnhThuCung != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await hinhAnhThuCung.CopyToAsync(ms);
                        thuCung.HinhAnhBase64 = Convert.ToBase64String(ms.ToArray());
                    }
                }

                _context.ThuCung.Add(thuCung);
                _context.SaveChanges();

                TempData["PetsMessage"] = "Thêm thú cưng mới thành công.";
                return RedirectToAction("Pets");
            }

            TempData["PetsMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các trường thông tin.";
            return View("Pets", model);
        }
        public IActionResult EditPet(int id)
        {
            var thuCung = _context.ThuCung.SingleOrDefault(tc => tc.MaThuCung == id);
            if (thuCung == null)
            {
                return NotFound();
            }

            var model = new EditPetViewModel
            {
                MaThuCung = thuCung.MaThuCung,
                TenThuCung = thuCung.TenThuCung,
                Loai = thuCung.Loai
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPet(EditPetViewModel model, IFormFile hinhAnhThuCung)
        {
            if (ModelState.IsValid)
            {
                var thuCung = _context.ThuCung.SingleOrDefault(tc => tc.MaThuCung == model.MaThuCung);
                if (thuCung == null)
                {
                    return NotFound();
                }

                thuCung.TenThuCung = model.TenThuCung;
                thuCung.Loai = model.Loai;

                if (hinhAnhThuCung != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await hinhAnhThuCung.CopyToAsync(ms);
                        thuCung.HinhAnhBase64 = Convert.ToBase64String(ms.ToArray());
                    }
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Pets");
            }

            return View(model);
        }




        public IActionResult DeletePet(int id)
        {
            var thuCung = _context.ThuCung.SingleOrDefault(tc => tc.MaThuCung == id);
            if (thuCung == null)
            {
                return NotFound();
            }

            return View(thuCung);
        }

        [HttpPost, ActionName("DeletePet")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuCung = await _context.ThuCung.FindAsync(id);
            if (thuCung != null)
            {
                _context.ThuCung.Remove(thuCung);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Pets));
        }
        // GET: Account/Appointments
        public async Task<IActionResult> Appointments()
        {
            var maKhachHang = User.FindFirstValue("MaKhachHang");
            if (maKhachHang == null)
            {
                return Challenge();
            }

            var appointments = await _context.LichHen
                .Include(lh => lh.KhachHang)
                .Include(lh => lh.ThuCung)
                .Include(lh => lh.DichVu)
                .Where(lh => lh.MaKhachHang.ToString() == maKhachHang)
                .Select(lh => new AppointmentViewModel
                {
                    MaLichHen = lh.MaLichHen,
                    NgayHen = lh.NgayHen,
                    TenThuCung = lh.ThuCung.TenThuCung,
                    TenDichVu = lh.DichVu.TenDichVu,
                    TrangThai = lh.TrangThai,
                    GioHen = lh.GioHen
                }).ToListAsync();

            return View(appointments);
        }
        // GET: Account/CreateAppointment
        public IActionResult CreateAppointment()
        {
            var maKhachHang = User.FindFirstValue("MaKhachHang");
            if (maKhachHang == null)
            {
                return Challenge();
            }

            var viewModel = new CreateAppointmentViewModel
            {
                ThuCungs = _context.ThuCung.Where(tc => tc.MaKhachHang.ToString() == maKhachHang).ToList(),
                DichVus = _context.DichVus.ToList()
            };

            return View(viewModel);
        }
        // POST: Account/CreateAppointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentViewModel model)
        {
            var maKhachHang = User.FindFirstValue("MaKhachHang");
            if (maKhachHang == null)
            {
                return Challenge();
            }

            if (ModelState.IsValid)
            {
                var lichHen = new LichHen
                {
                    NgayHen = model.NgayHen,
                    MaKhachHang = int.Parse(maKhachHang),
                    MaThuCung = model.MaThuCung,
                    MaDichVu = model.MaDichVu,
                    TrangThai = "Đang chờ duyệt",
                    GioHen = model.GioHen
                };

                _context.LichHen.Add(lichHen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Appointments));
            }

            model.ThuCungs = _context.ThuCung.Where(tc => tc.MaKhachHang.ToString() == maKhachHang).ToList();
            model.DichVus = _context.DichVus.ToList();
            return View(model);
        }
              
        // GET: Account/DeleteAppointment
        public async Task<IActionResult> DeleteAppointment(int? id)
        {
            var maKhachHang = User.FindFirstValue("MaKhachHang");
            if (maKhachHang == null)
            {
                return Challenge();
            }

            if (id == null)
            {
                return NotFound();
            }

            var lichHen = await _context.LichHen
                .Include(lh => lh.KhachHang)
                .Include(lh => lh.ThuCung)
                .Include(lh => lh.DichVu)
                .SingleOrDefaultAsync(m => m.MaLichHen == id && m.MaKhachHang.ToString() == maKhachHang);

            if (lichHen == null || lichHen.TrangThai != "Đang chờ duyệt")
            {
                return NotFound();
            }

            _context.LichHen.Remove(lichHen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Appointments));
        }
    }
}
