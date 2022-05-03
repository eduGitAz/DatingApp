using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public AppCompany AppCompany { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    } 
}