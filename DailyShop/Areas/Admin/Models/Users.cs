using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DailyShop.Areas.Admin.Models
{
    public class User
    {
        [Key]
        [DisplayName("Mã khách hàng")]
        public int Id { get; set; }
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Khách hàng")]
        public string Fullname { get; set; }
        [DisplayName("Giới tính")]
        public bool Gender { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phonenumber { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Trạng thái tài khoản")]
        public bool AccountStatus { get; set; }

        public List<Invoices> Invoices { get; set; }

    }
}
