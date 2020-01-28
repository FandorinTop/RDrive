using Microsoft.AspNetCore.Identity;
using RDrive.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RDrive.Entities.Entities
{
    [Table("AspNetUsers")]
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(50)]
        public string AddressLine { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDateAuth { get; set; }
        public DateTime CreationDateUTC { get; set; }
        public AppUser()
        {
            CreationDateUTC = DateTime.UtcNow;
        }
    }
}
