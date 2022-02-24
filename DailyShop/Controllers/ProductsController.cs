using DailyShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Controllers
{
    public class ProductsController : Controller
    {

        private readonly DailyShopContext _context;
        public ProductsController(DailyShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var productDetail = _context.Products.Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == id);
            return View(await productDetail);
        }


        [HttpGet]
        public async Task<IActionResult> SearchProduct(string keyword)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            //tim kiem theo ten
            var lstNameProducts = _context.Products.Where(p => p.ProductName.Contains(keyword));
            //if (_context.Products.FirstOrDefault(P => P.ProductName == keyword) == null)
            //{
            //    lstNameProducts = _context.Products.Include(p => p.ProductType).Where(p => p.ProductType.Name == keyword);
            //}
            return View(await lstNameProducts.ToListAsync());
        }


    }
}
