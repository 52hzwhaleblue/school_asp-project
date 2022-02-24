using DailyShop.Areas.Admin.Models;
using DailyShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly DailyShopContext _context;
        public AdminController(DailyShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            // hiển thị username từ cookie
            //if (HttpContext.Request.Cookies.ContainsKey("Username"))
            //{
            //    ViewBag.Username = HttpContext.Request.Cookies["Username"].ToString();
            //}
            //return View();


            // hiển thị username từ session
            if (HttpContext.Session.Keys.Contains("EmployeeUsername"))
            {
                ViewBag.EmployeeUsername = HttpContext.Session.GetString("EmployeeUsername");
            }
            else
            {
                ViewBag.ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu";
            }

            return View();

        }
        public IActionResult Login(string username, string password)
        {
            ViewBag.isLogin = true;
            Employee emp = _context.Employee.Where(i => i.Username == username && i.Password == password).FirstOrDefault();
            if (emp != null)
            {
                //////// tạo cookie
                //HttpContext.Response.Cookies.Append("Id", emp.Id.ToString());
                //HttpContext.Response.Cookies.Append("Username", emp.Username.ToString());
                //return RedirectToAction("Index", "Admin");


                //tạo session
                HttpContext.Session.SetInt32("empId", emp.Id);
                HttpContext.Session.SetString("EmployeeUsername", emp.Username);
                ViewBag.success_Login_Message = "Đăng nhập thành công";
                return RedirectToAction("Index", "Admin");
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
            HttpContext.Session.Remove("EmployeeUsername");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }
    }
}
