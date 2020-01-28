using RDrive.DataAccess.DataAccept;
using RDrive.DataAccess.Interfaces;
using RDrive.DataAccess.Repositories.Base;
using RDrive.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDrive.DataAccess.Repositories
{
    public class DriverRepositories : EFBaseIdentityRepository<Driver>, IDriverRepository
    {
        public DriverRepositories(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            List<Driver> drivers = await _context.Drivers.ToListAsync();
            return drivers;

       }
        public async Task<Driver> GetDriverByName(string name)
        {
            Driver driver = await _context.Drivers
                .FirstOrDefaultAsync(item => item.UserName.ToUpper().Equals(name.ToUpper()));

            return driver;
        }
    }
}
