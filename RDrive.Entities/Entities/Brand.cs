using RDrive.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RDrive.Entities.Entities
{
    public class Brand : BaseEntity
    {
        [MaxLength(20)]
        public string servicePhoneNumber { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string RegistrationAddress { get; set; }
        public ICollection<Model> Models { get; set; }
        public Brand()
        {
            Models = new List<Model>();
        }


    }
}
