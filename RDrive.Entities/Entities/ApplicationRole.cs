using Microsoft.AspNetCore.Identity;
using RDrive.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RDrive.Entities.Entities
{
    public class ApplicationRole : IdentityRole<int>, IBaseEntity
    {
        public ApplicationRole() : base()
        {
            CreationDateUTC = DateTime.UtcNow;
        }
        public ApplicationRole(string name) : base(name)
        {
            CreationDateUTC = DateTime.UtcNow;
        }

        public DateTime CreationDateUTC { get; set; }


    }

}
