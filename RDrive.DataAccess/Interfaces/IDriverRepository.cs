using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RDrive.DataAccess.Interfaces.Base;
using RDrive.Entities.Entities;

namespace RDrive.DataAccess.Interfaces
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        Task<List<Driver>> GetAllDrivers();
        Task<Driver> GetDriverByName(string name);
    }
}
