using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presistance.Services.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly CompleteGPSUtilityContext _context;

        public LocationRepository(CompleteGPSUtilityContext context)
        {
            _context = context;
        }


        public async Task<Location> FindByIdAsync(int id, bool include = false)
        {
            IQueryable<Location> result = _context.Locations;
            if (include)
            {
                result.Include(a => a.Device);
            }
            return await result.SingleOrDefaultAsync(a => a.LocationId == id);
        }

        public async Task<IEnumerable<Location>> GetAll(Device device, int from = 0, int to = int.MaxValue, int skip = 0, int take = 1000)
        {
            return await _context.Locations
                .Where(a => a.Device == device)
                .Where(a => a.TimeFrom2000 >= from && a.TimeFrom2000 <= to)
                .OrderByDescending(a => a.TimeFrom2000)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task Insert(Location location)
        {
            await _context.AddAsync(location);
        }

        public async Task Insert(IEnumerable<Location> locations)
        {
            await _context.AddRangeAsync(locations);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
