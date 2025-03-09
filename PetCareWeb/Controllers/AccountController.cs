﻿using Microsoft.AspNetCore.Authentication.Cookies;
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

namespace PetCareWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
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
                        new Claim(ClaimTypes.Email, khachHang.Email)
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

        // POST: Account/EditPet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPet(PetsViewModel model, IFormFile hinhAnhThuCung)
        {
            if (ModelState.IsValid)
            {
                var thuCung = _context.ThuCung.SingleOrDefault(tc => tc.MaThuCung == model.ThuCungs[0].MaThuCung);

                if (thuCung == null)
                {
                    TempData["PetsMessage"] = "Không tìm thấy thú cưng. Vui lòng thử lại.";
                    return View("Pets", model);
                }

                thuCung.TenThuCung = model.ThuCungs[0].TenThuCung;
                thuCung.Loai = model.ThuCungs[0].Loai;

                if (hinhAnhThuCung != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await hinhAnhThuCung.CopyToAsync(ms);
                        thuCung.HinhAnhBase64 = Convert.ToBase64String(ms.ToArray());
                    }
                }

                _context.SaveChanges();

                TempData["PetsMessage"] = "Cập nhật thú cưng thành công.";
                return RedirectToAction("Pets");
            }

            TempData["PetsMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các trường thông tin.";
            return View("Pets", model);
        }

        // POST: Account/DeletePet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePet(int maThuCung)
        {
            var thuCung = _context.ThuCung.SingleOrDefault(tc => tc.MaThuCung == maThuCung);

            if (thuCung == null)
            {
                TempData["PetsMessage"] = "Không tìm thấy thú cưng. Vui lòng thử lại.";
                return RedirectToAction("Pets");
            }

            _context.ThuCung.Remove(thuCung);
            _context.SaveChanges();

            TempData["PetsMessage"] = "Xóa thú cưng thành công.";
            return RedirectToAction("Pets");
        }
    }
}
