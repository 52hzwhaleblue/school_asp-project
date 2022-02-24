using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DailyShop.Areas.Admin.Models
{
    public class InvoicesDetail
    {
        [Key]
        [DisplayName("Mã chi tiết hóa đơn")]
        public int Id { get; set; }
        [DisplayName("Mã hóa đơn")]
        public int InvoiceId { get; set; }
        public Invoices Invoice { get; set; }
        [DisplayName("Mã sản phẩm")]
        public int ProductId { get; set; }
        public Product Products { get; set; }
        [DisplayName("Đơn giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Price { get; set; }
    }
}
