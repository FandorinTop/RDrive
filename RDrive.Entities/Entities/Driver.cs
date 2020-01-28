using RDrive.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RDrive.Entities.Entities
{
    public class Driver : AppUser
    {
   
        public bool IsVerified { get; set; }
        public bool isEnable { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public Driver()
        {
            Contracts = new List<Contract>();
        }
    }
}
