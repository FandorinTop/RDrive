using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RDrive.Entities.Entities
{
    public class Client : AppUser
    {
        
        [MaxLength(20)]
        public string Licence { get; set; }
        public ICollection<Car> CarList { get; set; }

        public Client() : base()
        {
            CarList = new List<Car>();
        }
    }
}
