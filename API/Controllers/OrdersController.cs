using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var orders = await _orderRepository.GetOrdersDtoAsync(id);

            return Ok(orders);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            return await _orderRepository.GetOrderDtoByIdAsync(id);

        } 

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

         [HttpPut("{id}")] 
         public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)  
        {
    
           var order = await _orderRepository.GetOrderByIdAsync(id);
            _mapper.Map(orderUpdateDto, order);
            _orderRepository.Update(order);
            

            if (await _orderRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Dane nie zostały zaktualizowane");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<OrderDto>> DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
            return NoContent();
        }

    }
}