using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<MemberDto> GetMemberDtoByIdAsync(int id);
        Task<MemberDto> GetMemberDtoByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersDtoAsync(int appCompanyId);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);    
        Task<IEnumerable<AppUser>> GetUsersAsync();  
        void Update(AppUser user);
        Task<bool> SaveAllAsync();  
    }
}