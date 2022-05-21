using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IDeviceRepository
    {    Task <DeviceDto> GetDeviceDtoByIdAsync(int id);
         Task <IEnumerable<DeviceDto>> GetDevicesDtoAsync(int appDeviceId);
         Task<AppDevice> GetDeviceByIdAsync(int id);
         Task<IEnumerable<AppDevice>> GetDevicesAsync();
         void Update(AppDevice device);  
         Task<bool> SaveAllAsync();
         Task <AppDevice> Add(AppDevice device);
         Task <AppDevice> Delete(int id);
    }
}