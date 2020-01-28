using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserRegisterVM
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(5, 100, ErrorMessage = "Age must be in range from 5 to 100 inclusive")]
        public int Age { set; get; }

        [Required]
        [Display(Name = "Type")]
        public string Type { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password")]
        public string PasswordConfirm { get; set; }
    }
}
