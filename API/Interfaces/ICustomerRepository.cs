using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICustomerRepository
    {   
         Task <CustomerDto> GetCustomerDtoByIdAsync(int id);
         Task <IEnumerable<CustomerDto>> GetCustomersDtoAsync(int appCompanyId);
         Task<AppCustomer> GetCustomerByIdAsync(int id);
         Task<IEnumerable<AppCustomer>> GetCustomersAsync();
         void Update(AppCustomer customer);  
         Task<bool> SaveAllAsync();
         Task <AppCustomer> Add(AppCustomer customer);
         Task <AppCustomer> Delete(int id);
    }
}