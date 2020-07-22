using Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Services.Repositories
{
    public interface ILocationRepository
    {
        public IEnumerable<Location> GetAll(int skip = 0, int take = 1000);
        public Task<Location> FindByIdAsync(int id);
        public Task Insert(Location location);
        public Task Insert(IEnumerable<Location> locations);
        public Task<bool> Delete(int id);
        public void Update(Location location);
        public Task<int> SaveAsync();
    }
}
