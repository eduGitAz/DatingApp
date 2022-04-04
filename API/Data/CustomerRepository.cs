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
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<AppCustomer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<AppCustomer> GetCustomerByNameAsync(string name)
        {
                return await _context.
                Customers.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<CustomerDto> GetCustomerDtoAsync(string name)
        {
                return await _context.Customers
                .Where(x => x.Name == name)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AppCustomer>> GetCustomersAsync()
        {
               return await _context.Customers
              .ToListAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersDtoAsync()
        {
                return await _context.Customers
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppCustomer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}