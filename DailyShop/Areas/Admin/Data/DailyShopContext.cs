using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DailyShop.Areas.Admin.Models;
using DailyShop.Models;

namespace DailyShop.Data
{
    public class DailyShopContext : DbContext
    {
        public DailyShopContext(DbContextOptions<DailyShopContext> options)
            : base(options)
        {
        }
        public DbSet<Role> Role { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductType { get; set; }
    }
}
