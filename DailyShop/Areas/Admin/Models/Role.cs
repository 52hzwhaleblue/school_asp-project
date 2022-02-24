using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DailyShop.Areas.Admin.Models
{
    public class Role
    {
        [Key]
        [DisplayName("Mã phân quyền")]
        public int Id { get; set; }
        [DisplayName("Tên phân quyền")]
        public string Position { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
