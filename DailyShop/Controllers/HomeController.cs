using DailyShop.Areas.Admin.Models;
using DailyShop.Data;
using DailyShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly DailyShopContext _context;
        public HomeController(DailyShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // hiển thị username từ session
            if (HttpContext.Session.Keys.Contains("username"))
            {
                ViewBag.username = HttpContext.Session.GetString("username");
            }
            else
            {
                ViewBag.ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu";
            }

            //List<Products> lstProduct = new List<Products>();
            //ViewBag.ProductList = lstProduct;

            ViewBag.Cart = _context.Carts.ToList(); // load giỏ hàng ở header

            int sl = _context.Carts.Include(prop => prop.Product).Where(prop => prop.User.Username == HttpContext.Session.GetString("username")).Count();
            ViewBag.soluong = sl;

            return View(_context.Products.ToList());
        }


        public IActionResult Login(string username, string password)
        {
            ViewBag.isLogin = true;
            User user = _context.Users.Where(i => i.Username == username && i.Password == password).FirstOrDefault();
            if (user != null)
            {
                //////// tạo cookie
                //HttpContext.Response.Cookies.Append("Id", emp.Id.ToString());
                //HttpContext.Response.Cookies.Append("Username", emp.Username.ToString());
                //return RedirectToAction("Index", "Admin");


                //tạo session
                HttpContext.Session.SetInt32("userId", user.Id);
                HttpContext.Session.SetString("username", user.Username);
                ViewBag.success_Login_Message = "Đăng nhập thành công";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.failed_Login_Message = "Đăng nhập thất bại";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
