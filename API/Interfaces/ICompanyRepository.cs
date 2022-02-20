using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICompanyRepository
    {
        void Update(AppCompany company);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppCompany>> GetCompanyAsync();  
         Task<AppCompany> GetCompanyByIdAsync(int id);
         Task<AppCompany> GetCompanyByNameAsync(string name);
         Task <IEnumerable<CompanyDto>> GetCompaniesDtoAsync();
         Task <CompanyDto> GetCompanyDtoAsync(string name);
    }
}