using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrderStatusRepository : IOrderStatusRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OrderStatusRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<OrderStatusDto>> GetOrderStatusDtoAsync()
        {
            return await _context.OrderStatuses
                .ProjectTo<OrderStatusDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}