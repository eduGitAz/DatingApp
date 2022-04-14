using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IRepository<T1> where T1 : class
    {
         Task <IEnumerable<T1>> GetAll(T1 entity);
         Task <T1> GetById(int id);
         Task<T1> Insert(T1 entity);
         Task Update(T1 entity);
         Task <T1> Delete(int id);
         Task<bool> SaveAllAsync();
 
    }
}