﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.AdminViewModels.DriverViewModel
{
    public class CreateNewDriverAdminView
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public bool IsVerified { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

    }
}
