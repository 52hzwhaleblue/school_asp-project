using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Areas.Admin.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Mã nhân viên")]
        public int Id { get; set; }
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Nhân viên")]
        public string Fullname { get; set; }
        [DisplayName("Giới tính")]
        public bool Gender { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phonenumber { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Trạng thái tài khoản")]
        public bool Status { get; set; }
        [DisplayName("Mã phân quyền")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Invoices> Invoices { get; set; }
    }
}
