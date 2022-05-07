using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IOrderRepository
    {

        Task <OrderDto> GetOrderDtoByIdAsync(int id);
        Task <IEnumerable<OrderDto>> GetOrdersDtoAsync(int appCompanyId);
        Task<AppOrder> GetOrderByIdAsync(int id);
        Task<IEnumerable<AppOrder>> GetOrdersAsync();
        void Update(AppOrder customer);  
        Task<bool> SaveAllAsync();
        Task <AppOrder> Add (AppOrder order);
        Task <AppOrder> Delete (int id);
          
    }
}