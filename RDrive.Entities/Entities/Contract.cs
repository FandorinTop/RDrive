using RDrive.Entities.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RDrive.Entities.Entities
{
    public class Contract : BaseEntity
    {
        public DateTime ExpirationDateAuth { get; set; }
        public DateTime RegistrateDate { get; set; }
        public bool IsEnded { get; set; }
        public int? CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public int? DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; }
    }
}
