using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IDevicesRepository
    {
        void Update(AppDevice device);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppDevice>> GetDevicesAsync();  
         Task<AppDevice> GetDeviceByIdAsync(int id);
         Task<AppDevice> GetDeviceByNameAsync(string name);
         Task <IEnumerable<DeviceDto>> GetDeviceDtoAsync();
         Task <AppDevice> GetDeviceDtoAsync(string name);
    }
}