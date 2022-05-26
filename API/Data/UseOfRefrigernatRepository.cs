using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UseOfRefrigernatRepository : IUseOfRefrigernatRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UseOfRefrigernatRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<UseOfRefrigernatDto>> GetUseOfRefrigernatDtoAsync()
        {
                return await _context.UseOfRefrigernats
                .ProjectTo<UseOfRefrigernatDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}