using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presistance.Services.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly CompleteGPSUtilityContext _context;

        public DeviceRepository(CompleteGPSUtilityContext context)
        {
            _context = context;
        }

        public async Task<Device> FindByIdAsync(int id)
        {
            return await _context.Devices.SingleOrDefaultAsync(a => a.DeviceId == id);
        }

        public async Task<IEnumerable<Device>> GetAll(int skip = 0, int take = 1000)
        {
            return await _context.Devices
                          .OrderBy(a => a.DeviceId)
                          .Skip(skip)
                          .Take(take)
                          .ToListAsync();
        }

        public async Task Insert(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task Insert(IEnumerable<Device> devices)
        {
            await _context.Devices.AddRangeAsync(devices);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
