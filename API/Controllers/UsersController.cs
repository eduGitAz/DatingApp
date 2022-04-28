using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(UserManager<AppUser> userManager, IUserRepository userRepository, IMapper mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var users = await _userRepository.GetMembersDtoAsync(id);
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            return await _userRepository.GetMemberDtoByIdAsync(id);

        } 

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> SearchMember(SearchDto search)
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            int id = currentUser.AppCompany.Id;

            var users = await _userRepository.SearchMember(id, search.search);
            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("add")] 
         public async Task<ActionResult> AddUser(MemberAddDto memberAddDto)
        {

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
          

            if (await UserExists(memberAddDto.Username)) return BadRequest("Username is taken");

            AppUser user = new AppUser{
                UserName = memberAddDto.Username,
                Name = memberAddDto.Name,
                Surname = memberAddDto.Surname,
                AppCompany = currentUser.AppCompany
            }; 

            user.UserName = memberAddDto.Username.ToLower(); 
            var result = await _userManager.CreateAsync(user, memberAddDto.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Installer");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }
        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        } 


         [Authorize(Policy = "RequireAdminRole")]
         [HttpPut("{id}")]
         public async Task<ActionResult> UpdateUser(int id, MemberUpdateDto memberUpdateDto)
        {
    
           var user = await _userRepository.GetUserByIdAsync(id);
            _mapper.Map(memberUpdateDto, user);
            _userRepository.Update(user);
            

            if (await _userRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Dane nie zostały zaktualizowane");
        }

       
        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return Ok();
        }

      

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUsersWithRoles()
        {

            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userRepository.GetUserByUsernameAsync(userName);
        
            var users = await _userManager.Users
            .Include(r => r.UserRoles)
            .ThenInclude (r => r.Role) 
            .Where(x => x.AppCompany.Id == user.AppCompany.Id)
            .OrderBy(u => u.UserName)
            .Select (u => new 
            {
                u.Id,
                Username = u.UserName,
                Name = u.Name,
                Surname = u.Surname,
                Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
            })
            .ToListAsync();
            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles (string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("Could not find user");
            
            var userRoles = await _userManager.GetRolesAsync(user);
            
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if(!result.Succeeded) return BadRequest("Failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            if(!result.Succeeded) return BadRequest("Failed to remove from roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }
  
    }
    
         
    
}

