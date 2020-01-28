using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RDrive.Entities.Entities.Base;

namespace RDrive.Entities.Entities
{
    public class Car :  BaseEntity
    {        
        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(20)]
        public string Number { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public int? ModelId { get; set; }
        [ForeignKey(nameof(ModelId))]
        public Model Model { get; set; }
        public DateTime dateOfInspection {get;set;}

        public bool IsEnabled { get; set; }
        public bool IsHandbrakeActive { get; set; } = false;
        public double Speed { get; set; }
        public double SteeringAngle { get; set; }
        public DateTime lastUpdate { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public Car()
        {
            Contracts = new List<Contract>();
        }

    }
  
}
