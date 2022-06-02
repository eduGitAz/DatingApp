using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderStatusesController: BaseApiController
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;

        public OrderStatusesController(IOrderStatusRepository orderStatusRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderStatusRepository = orderStatusRepository;
           
        }

        [Authorize(Policy = "RequireInstallerRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatusDto>>> GetOrderStatusDto()
        {
        
            var orderStatses = await _orderStatusRepository.GetOrderStatusDtoAsync();

            return Ok(orderStatses);
        } 
    }
}