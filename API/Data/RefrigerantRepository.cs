using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RefrigerantRepository : IRefrigerantRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RefrigerantRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<RefrigerantDto>> GetRefrigerantDtoAsync()
        {
              return await _context.Refrigerants
                .ProjectTo<RefrigerantDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}