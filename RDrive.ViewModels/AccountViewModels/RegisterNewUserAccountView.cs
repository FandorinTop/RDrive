using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.AccountViewModels
{
    public class RegisterNewUserAccountView
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Uri CurrentUrl { get; set; }
    }
}
