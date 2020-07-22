using Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Services.Repositories
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAll(Device device, int from = 0, int to = int.MaxValue, int skip = 0, int take = 1000);
        public Task<Location> FindByIdAsync(int id, bool include = false);
        public Task Insert(Location location);
        public Task Insert(IEnumerable<Location> locations);
        public Task<int> SaveAsync();
    }
}
