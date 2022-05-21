using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DeviceRepository: IDeviceRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DeviceRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DeviceDto> GetDeviceDtoByIdAsync(int id)
        {
            return await _context.Devices
                .Where(x => x.Id == id)
                .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<DeviceDto>> GetDevicesDtoAsync(int appCompanyId)
        {
                return await _context.Devices
                .Where(x => x.AppCompany.Id == appCompanyId)
                .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<AppDevice> GetDeviceByIdAsync(int id)
        {
             return await _context.Devices 
            .Include(a => a.AppCompany)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AppDevice>> GetDevicesAsync()
        {
               return await _context.Devices
              .ToListAsync();
        }

        public void Update(AppDevice device)
        {
            _context.Entry(device).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<AppDevice> Add(AppDevice device)
        {
            await _context.Devices.AddAsync(device);
            _context.SaveChanges();
            return device;
        }

        public async Task<AppDevice> Delete(int id)
        {
            var result = await _context.Devices
            .FirstOrDefaultAsync( c => c.Id == id);
            if(result != null)
            {
                _context.Devices.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }   

            return null;
        }

   
    }
}