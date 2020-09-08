using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xianMvcDemo.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}