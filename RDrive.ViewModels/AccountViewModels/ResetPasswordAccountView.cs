using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.AccountViewModels
{
    public class ResetPasswordAccountView
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
