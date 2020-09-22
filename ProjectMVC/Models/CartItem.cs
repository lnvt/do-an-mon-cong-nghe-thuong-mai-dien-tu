using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }

        [MinLength(10,ErrorMessage ="Tên người nhận ít nhất là 10 kí tự!")]
        public string shipName { set; get; }
        [Required(ErrorMessage = "Phải có số điện thoại người nhận!")]
        public string mobile { set; get; }
        [Required(ErrorMessage = "Phải nhập địa chỉ!")]
        public string address { set; get; }
        [EmailAddress(ErrorMessage = "Phải nhập đúng địa chỉ gmail. Ví dụ: abc@gmail.com")]
        public string email { set; get; }
  
    }
}