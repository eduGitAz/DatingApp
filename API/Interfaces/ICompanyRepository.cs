using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICompanyRepository
    {
         Task <CompanyDto> GetCompanyDtoByIdAsync(int id);
         Task <CompanyDto> GetCompanyDtoByNameAsync(string name);
         Task <IEnumerable<CompanyDto>> GetCompaniesDtoAsync();
         Task<AppCompany> GetCompanyByIdAsync(int id);
         Task<AppCompany> GetCompanyByNameAsync(string name);
         Task<IEnumerable<AppCompany>> GetCompaniesAsync();
         void Update(AppCompany company);
         Task<bool> SaveAllAsync();
         Task <AppCompany> Add (AppCompany company);
    }
}