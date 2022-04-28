using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
         void Update(AppUser user);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppUser>> GetUsersAsync();  
         Task<AppUser> GetUserByIdAsync(int id);
         Task<AppUser> GetUserByUsernameAsync(string username);       
         Task<IEnumerable<MemberDto>> GetMembersDtoAsync(int appCompanyId);
         Task<MemberDto> GetMemberDtoByUsernameAsync(string username);
         Task<MemberDto> GetMemberDtoByIdAsync(int id);
         Task<IEnumerable<MemberDto>> SearchMember(int appCompanyId, string search);
    }
}