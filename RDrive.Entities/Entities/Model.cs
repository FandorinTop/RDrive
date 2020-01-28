using RDrive.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RDrive.Entities.Entities
{
    public class Model : BaseEntity
    {
        [MaxLength(20)]
        public string models { get; set; }
        [MaxLength(20)]
        public string clas { get; set; }    
        public int? BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
    }
}
