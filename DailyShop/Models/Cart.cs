using DailyShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        // khóa ngoại
        [DisplayName("Mã khách hàng")]
        public int UserId { get; set; }
        public User User { get; set; }
        //
        // khóa ngoại
        [DisplayName("Mã sản phẩm")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        //

        [DisplayName("Hình ảnh")]
        public string Image { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string product_name { get; set; }

        [DisplayName("Hình ảnh")]
        public int Price { get; set; }

        [DisplayName("Số lượng sản phẩm")]
        public int Quantity { get; set; }

        [DisplayName("Đơn giá")]
        public int subTotal { get; set; }

        [DisplayName("Tổng tiền")]
        public int Total { get; set; }


    }
}
