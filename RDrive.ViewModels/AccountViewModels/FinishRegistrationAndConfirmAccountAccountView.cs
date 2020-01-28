using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.AccountViewModels
{
    public class FinishRegistrationAndConfirmAccountAccountView
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
