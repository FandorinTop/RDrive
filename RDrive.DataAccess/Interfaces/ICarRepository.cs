using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RDrive.DataAccess.Interfaces.Base;
using RDrive.Entities.Entities;

namespace RDrive.DataAccess.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> FindCarByNumber(string number);
    }
}
