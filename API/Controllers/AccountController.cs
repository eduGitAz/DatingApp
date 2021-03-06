using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITokenService _tokenServie;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenServie, IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenServie = tokenServie;
            _companyRepository = companyRepository;
        } 

        [HttpPost("register")] 
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            AppCompany company = new AppCompany {
               Name = registerDto.CompanyName,
               TaxNumber = registerDto.TaxNumber,
               FgazNumber = registerDto.FgazNumber,
               StreetNumber = registerDto.StreetNumber,
               City = registerDto.City,
               PostCode = registerDto.PostCode,
            };

            AppUser user = new AppUser{
                UserName = registerDto.Username,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
            }; 


            company = await _companyRepository.Add(company);
            user.AppCompany = company;

            user.UserName = registerDto.Username.ToLower(); 
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenServie.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            
            if (user == null) return Unauthorized("Nieprawid??owy login lub has??o");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Nieprawid??owy login lub has??o");

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenServie.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}