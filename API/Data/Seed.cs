using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedCompanies(DataContext context)
        {
           if (await context.Companies.AnyAsync()) return;

            var companiesData = await System.IO.File.ReadAllTextAsync("Data/CompanySeedData.json");
            var companies = JsonSerializer.Deserialize<List<AppCompany>>(companiesData);

            foreach (var company in companies)
            {
               
                foreach (var user in company.Users)
                {
                   
                    using var hmac = new HMACSHA512();

                    user.UserName = user.UserName.ToLower();
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                    user.PasswordSalt = hmac.Key;
                   
                    context.Users.Add(user);
                }
            
                context.Companies.Add(company);
            }
        
            await context.SaveChangesAsync();

        }
    }
}