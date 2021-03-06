using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DevicesController:  BaseApiController
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        public DevicesController(IDeviceRepository deviceRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            _userRepository = userRepository;
        }
        
        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDto>>> GetDevices()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var devices = await _deviceRepository.GetDevicesDtoAsync(id);

            return Ok(devices);
        } 
        
        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("count")]
        public async Task<ActionResult<IEnumerable<DeviceDto>>> CountDevices()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var devices = await _deviceRepository.GetDevicesDtoAsync(id);
               int i = 0;
            foreach (var item in devices)
            {
                i++;
            }

            return Ok(i);
        } 
        [Authorize(Policy = "RequireManagerRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDto>> GetDevice(int id)
        {
            return await _deviceRepository.GetDeviceDtoByIdAsync(id);

        } 

        [Authorize(Policy = "RequireManagerRole")]
        [HttpPost("add")] 
         public async Task<ActionResult> AddDevice(DeviceDto deviceDto)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);

            AppDevice device = new AppDevice{
                Name = deviceDto.Name,
                Power = deviceDto.Power,
                Color = deviceDto.Color,
                Price = deviceDto.Price,
                AppCompany = currentUser.AppCompany
            }; 

            var result = await _deviceRepository.Add(device);
           
            return Ok(); 
        }

        [Authorize(Policy = "RequireManagerRole")]
        [HttpPut("{id}")] 
         public async Task<ActionResult> UpdateDevice(int id, DeviceUpdateDto deviceUpdateDto)  
        {
    
           var device = await _deviceRepository.GetDeviceByIdAsync(id);
           _mapper.Map(deviceUpdateDto, device);
           _deviceRepository.Update(device);
            

            if (await _deviceRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Dane nie zosta??y zaktualizowane");
        }
        [Authorize(Policy = "RequireManagerRole")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CustomerDto>> DeleteDevice(int id)
        {
            await _deviceRepository.Delete(id);
            return NoContent();
        }
    }
}