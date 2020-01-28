using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserLoginVM
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { set; get; }

        [Display(Name = "Remember?")]
        public bool RememberMe { set; get; }

        public string ReturnUrl { set; get; }
    }
}
