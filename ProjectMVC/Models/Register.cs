using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class Register
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [MinLength(10,ErrorMessage ="Tên ít nhất có 10 kí tự")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Số điện thoại")]
        [Range(0 ,10)]
        public string Phone { get; set; }
    }
}