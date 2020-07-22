using Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Services.Repositories
{
    public interface IDeviceRepository
    {
        public Task<IEnumerable<Device>> GetAll(int skip = 0, int take = 1000);
        public Task<Device> FindByIdAsync(int id);
        public Task Insert(Device device);
        public Task Insert(IEnumerable<Device> devices);
        public Task<int> SaveAsync();
    }
}
