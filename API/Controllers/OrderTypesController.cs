using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderTypesController: BaseApiController
    {
        private readonly IOrderTypeRepository _orderTypeRepository;
        private readonly IMapper _mapper;

        public OrderTypesController(IOrderTypeRepository orderTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderTypeRepository = orderTypeRepository;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTypeDto>>> GetOrderTypeDto()
        {
        
            var orderTypes = await _orderTypeRepository.GetOrderTypeDtoAsync();

            return Ok(orderTypes);
        } 
    }
}