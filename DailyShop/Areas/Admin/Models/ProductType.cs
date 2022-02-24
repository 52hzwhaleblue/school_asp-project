using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DailyShop.Areas.Admin.Models
{
    public class ProductType
    {
        [Key]
        [DisplayName("Mã Loại sản phẩm")]
        public int Id { get; set; }
        [DisplayName("Tên loại")]
        public string Name { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
