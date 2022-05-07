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

        public async Task<CustomerDto> GetCustomerDtoByIdAsync(int id)
        {
            return await _context.Customers
                .Where(x => x.Id == id)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
     
        public async Task<IEnumerable<CustomerDto>> GetCustomersDtoAsync(int appCompanyId)
        {
                return await _context.Customers
                .Where(x => x.AppCompany.Id == appCompanyId)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task<AppCustomer> GetCustomerByIdAsync(int id)
        {
             return await _context.Customers 
            .Include(a => a.AppCompany)
            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AppCustomer>> GetCustomersAsync()
        {
               return await _context.Customers
              .ToListAsync();
        }

        public void Update(AppCustomer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<AppCustomer> Add(AppCustomer customer)
        {
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
            return customer;
        }

        public async Task<AppCustomer> Delete(int id)
        {
            var result = await _context.Customers
            .FirstOrDefaultAsync( c => c.Id == id);
            if(result != null)
            {
                _context.Customers.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }   

            return null;
        }
    

        
    }
}