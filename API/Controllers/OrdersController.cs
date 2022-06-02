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
    public class OrdersController: BaseApiController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        public OrdersController(IOrderRepository orderRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }
        
        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var orders = await _orderRepository.GetOrdersDtoAsync(id);

            return Ok(orders);
        } 

        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("count")]
        public async Task<int> CountOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var result = await _orderRepository.CountAllOrdersDtoAsync(id);
            return result;
          
        } 

        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("newOrder")]
        public async Task<int> CountNewOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var result = await _orderRepository.CountNewOrdersDtoAsync(id);
           
            return result;
        } 

         [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("realizedOrder")]
        public async Task<int> CountRealizedOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var result = await _orderRepository.CountRealizedOrdersDtoAsync(id);
          
           return result;
        } 

         [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("closedOrder")]
        public async Task<int> CountClosedOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var result = await _orderRepository.CountClosedOrdersDtoAsync(id);
            return result;
        
        } 

        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("percentOfServices")]
        public async Task<int> CountPercentOfServicesOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var service = await _orderRepository.CountPercentOfServicesOrders(id);
            var all = await _orderRepository.CountAllOrdersDtoAsync(id);

            var result = (service*100) / all;
            return result;
      
        } 

        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("percentOfInstallation")]
        public async Task<int> CountPercentOfInstallationOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var installation = await _orderRepository.CountPercentOfInstallationOrders(id);
            var all = await _orderRepository.CountAllOrdersDtoAsync(id);

            var result = ( installation * 100) / all;
            return result;
      
        } 

        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            return await _orderRepository.GetOrderDtoByIdAsync(id);

        } 

        [Authorize(Policy = "RequireManagerRole")]
        [HttpPost("add")] 
         public async Task<ActionResult> AddOrder(OrderDto orderDto)
        {

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
          

            AppOrder order = new AppOrder{
                CustomerId = orderDto.CustomerId,
                DeviceId = orderDto.DeviceId,
                ScheduledDate = orderDto.ScheduledDate,
                OrderStatusId = orderDto.OrderStatusId,
                OrderTypeId = orderDto.OrderTypeId,
                UseOfRefrigernatId = orderDto.UseOfRefrigernatId,
                RefrigerantId = orderDto.RefrigerantId,
                Weight = orderDto.Weight,
                AppCompany = currentUser.AppCompany
            }; 

            
            var result = await _orderRepository.Add(order);
           
            return Ok(); 
        }
        

         [Authorize(Policy = "RequireInstallerRole")]
         [HttpPut("{id}")] 
         public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)  
        {
    
           var order = await _orderRepository.GetOrderByIdAsync(id);
            _mapper.Map(orderUpdateDto, order);
            _orderRepository.Update(order);
            

            if (await _orderRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Dane nie zostały zaktualizowane");
        }

        [Authorize(Policy = "RequireManagerRole")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<OrderDto>> DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
            return NoContent();
        }

    }
}