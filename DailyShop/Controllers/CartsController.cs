using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DailyShop.Areas.Admin.Models;
using DailyShop.Data;
using Microsoft.AspNetCore.Http;
using DailyShop.Models;

namespace DailyShop.Controllers
{
    public class CartsController : Controller
    {
        private readonly DailyShopContext _context;

        public CartsController(DailyShopContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
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


          
            var cart = _context.Carts.Include(prop => prop.Product).Where(prop => prop.User.Username == HttpContext.Session.GetString("username"));
            ViewBag.Cart = cart;// load giiỏ hàng ở trong View Cart -> index

            return View(await cart.ToListAsync());
        }


        public IActionResult Add(int Id)
        {
            return Add(Id, 1);
        }

        [HttpPost]
        public IActionResult Add(int productId, int quantity)
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = _context.Users.FirstOrDefault(acc => acc.Username == username).Id;
            Cart carts = _context.Carts.Include(p => p.Product).FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);
            string img = _context.Products.FirstOrDefault(acc => acc.Id == productId).Image;
            int price = _context.Products.FirstOrDefault(acc => acc.Id == productId).Price;
            string prodName = _context.Products.FirstOrDefault(acc => acc.Id == productId).ProductName;


            if (carts == null)
            {
                carts = new Cart();
                carts.ProductId = productId;
                carts.UserId = userId;
                carts.Image = img;
                carts.product_name = prodName;
                carts.Quantity = quantity;
                carts.Price = price;
                carts.subTotal = price * quantity;
                carts.Total += carts.subTotal;
                _context.Carts.Add(carts);

            }
            else
            {
                carts.Quantity += quantity;
                carts.subTotal = price * carts.Quantity;

            }
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductId,ProductQuantity,importedDate,ProductStatus")] Cart carts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carts);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts.FindAsync(id);
            if (carts == null)
            {
                return NotFound();
            }
            return View(carts);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductId,ProductQuantity,importedDate,ProductStatus")] Cart carts)
        {
            if (id != carts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartsExists(carts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carts);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carts = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(carts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartsExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
