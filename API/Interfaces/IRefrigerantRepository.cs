using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IRefrigerantRepository
    {
         Task <IEnumerable<RefrigerantDto>> GetRefrigerantDtoAsync();
    }
}