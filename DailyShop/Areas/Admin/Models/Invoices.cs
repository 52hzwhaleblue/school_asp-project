using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DailyShop.Areas.Admin.Models
{
    public class Invoices
    {

        [Key]
        [DisplayName("Mã hóa đơn")]
        public int Id { get; set; }
        // khóa ngoại
        [DisplayName("Mã nhân viên")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        //
        // khóa ngoại
        [DisplayName("Mã khách hàng")]
        public int UserId { get; set; }

        public User Users { get; set; }
        //
        [DisplayName("Ngày lập hóa đơn")]
        [DataType(DataType.DateTime)]
        public DateTime importedDate { get; set; } = DateTime.Now;
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Giá bán (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Price { get; set; }

        [DisplayName("Tổng tiền (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DefaultValue(0)]
        public int Total { get; set; } = 0;

        [DisplayName("Còn hiệu lực")]
        [DefaultValue(0)]
        public int Status { get; set; } = 0;

        public List<InvoicesDetail> InvoicesDetail { get; set; }
    }
}
