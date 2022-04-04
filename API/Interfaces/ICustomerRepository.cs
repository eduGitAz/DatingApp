using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {
         
         void Update(AppCustomer customer);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppCustomer>> GetCustomersAsync();  
         Task<AppCustomer> GetCustomerByIdAsync(int id);
         Task<AppCustomer> GetCustomerByNameAsync(string name);
         Task <IEnumerable<CustomerDto>> GetCustomersDtoAsync();
         Task <CustomerDto> GetCustomerDtoAsync(string name);
    }
}