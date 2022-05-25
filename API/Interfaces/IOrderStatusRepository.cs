using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IOrderStatusRepository
    {
         Task <IEnumerable<OrderStatusDto>> GetOrderStatusDtoAsync();

    }
}