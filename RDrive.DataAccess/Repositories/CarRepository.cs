using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDrive.DataAccess.DataAccept;
using RDrive.DataAccess.Interfaces;
using RDrive.DataAccess.Repositories.Base;
using RDrive.Entities.Entities;

namespace RDrive.DataAccess.Repositories
{
    class CarRepository : EFBaseRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Car> FindCarByNumber(string number)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(f => f.Number.Equals(number));
            return car;
        }
    }
}
