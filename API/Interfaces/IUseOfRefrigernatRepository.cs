using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IUseOfRefrigernatRepository
    {
        Task <IEnumerable<UseOfRefrigernatDto>> GetUseOfRefrigernatDtoAsync();
    }
}