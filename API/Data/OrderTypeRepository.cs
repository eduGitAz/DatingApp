using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrderTypeRepository: IOrderTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrderTypeRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

         public async Task<IEnumerable<OrderTypeDto>> GetOrderTypeDtoAsync()
        {
            return await _context.OrderTypes
                .ProjectTo<OrderTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}