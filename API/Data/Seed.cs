using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
     public static class Seed
    {
        public static async Task SeedCompanies(DataContext context, UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
  
        {
            if (await context.Companies.AnyAsync()) return;
            var companiesData = await System.IO.File.ReadAllTextAsync("Data/CompanySeedData.json");
            var companies = JsonSerializer.Deserialize<List<AppCompany>>(companiesData);

            var roles = new List<AppRole>
            {
                new AppRole {Name = "Admin"},
                new AppRole {Name = "Manager"},
                new AppRole {Name = "Installer"},
            };
            
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }


            foreach (var company in companies)
            {
                foreach (var user in company.Users)
                {
                    user.UserName = user.UserName.ToLower();
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Manager");
                }

                 foreach (var customer in company.Customers)
                {
                    await context.Customers.AddAsync(customer);
                }
              
              await context.Companies.AddAsync(company);
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };
            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] {"Admin", "Manager"});

           await context.SaveChangesAsync();

        }
         
    }
}