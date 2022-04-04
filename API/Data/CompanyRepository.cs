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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CompanyRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompaniesDtoAsync()
        {
            return await _context.Companies
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<CompanyDto> GetCompanyDtoAsync(string name)
        {
            return await _context.Companies
            .Where(x => x.Name == name)
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AppCompany>> GetCompanyAsync()
        {
            return await _context.Companies
            .Include(u => u.Users)
            .ToListAsync();
        }

        public async Task<AppCompany> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<AppCompany> GetCompanyByNameAsync(string name)
        {
            return await _context.Companies
            .Include(u => u.Users)
            .Include(c => c.Customers)
            .SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppCompany company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }
    }
}