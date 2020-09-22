using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class LoginModel
    {
        //[Key]
        [Required(ErrorMessage = "Mời bạn nhập user name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Mời bạn nhập password")]
        public string Password { set; get; }
    }
}