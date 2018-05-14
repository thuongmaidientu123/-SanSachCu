using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web1._0.Models
{
    public class LoginModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập")]
        public string userName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẫu")]
        public string passWord { get; set; }
    }
}