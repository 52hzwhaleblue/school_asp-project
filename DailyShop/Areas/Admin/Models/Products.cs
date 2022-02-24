using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DailyShop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DailyShop.Areas.Admin.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int Id { get; set; }

        //[DataType(DataType.Upload)]
        [Display(Name = "Hình ảnh")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; }
        // khóa ngoại
        [DisplayName("Loại sản phẩm")]
        public int ProductTypeId { get; set; }
        [DisplayName("Màu sắc")]
        public string Color { get; set; }
        [DisplayName("Kích thước")]
        public string Size { get; set; }
        [DisplayName("Chất liệu")]
        public string Material { get; set; }

        public ProductType ProductType { get; set; }
        //
        [DisplayName("Ngày nhập hàng")]
        [DataType(DataType.DateTime)]
        public DateTime ImportedDate { get; set; }


        [DisplayName("Giá nhập (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int ImportedPrice { get; set; }

        [DisplayName("Giá bán (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Price { get; set; }
        [DisplayName("Mô tả sản phẩm")]
        public string Description { get; set; }


        [DisplayName("Số lượng tồn kho")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int QuantityStock { get; set; }

        [DisplayName("Số lượng nhập hàng")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int QuantityBought { get; set; }

        [DisplayName("Trạng thái sản phẩm")]
        public bool Status { get; set; }
        public List<Cart> Carts { get; set; }
        public List<InvoicesDetail> InvoicesDetail { get; set; }
    }
}
