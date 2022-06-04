using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IComparisionRepository
    {
         Task<IEnumerable<AppComparision>> GetComparision(int id);
    }
}