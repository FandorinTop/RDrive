using System;
using System.ComponentModel.DataAnnotations;
using RDrive.Entities.Interfaces;

namespace RDrive.Entities.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity( )
        {
            CreationDateUTC = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreationDateUTC { get; set; }

    }
}
