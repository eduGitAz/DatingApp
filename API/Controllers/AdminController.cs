using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;

        public AdminController(UserManager<AppUser> userManager,IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
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


        [Authorize(Policy = "BossPhotoRole")]
        [HttpGet("photos-to-moderate")]
        public ActionResult GetPhotosForBoss()
        {
            return Ok("Admins or moderators can see this");
        }
    }
}