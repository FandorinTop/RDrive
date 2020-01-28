using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RDrive.Entities.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }
        DateTime CreationDateUTC { get; set; }
    }
}
