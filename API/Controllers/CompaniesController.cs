using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CompaniesController : BaseApiController
    {
        private readonly ICompanyRepository _comapnyRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
    
        public CompaniesController(ICompanyRepository comapnyRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _comapnyRepository = comapnyRepository;
            _userRepository = userRepository;
        }
        
     

        [HttpGet]
        public async Task<ActionResult<CompanyDto>> GetCompany()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);

            return await _comapnyRepository.GetCompanyDtoByIdAsync(currentUser.AppCompany.Id);

        }

        [HttpPut("{id}")]
         public async Task<ActionResult> UpdateCompany(int id, CompanyUpdateDto companyUpdateDto)  
        {
          
            var company = await _comapnyRepository.GetCompanyByIdAsync(id);
            _mapper.Map(companyUpdateDto, company);
            _comapnyRepository.Update(company);
            

            if (await _comapnyRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Dane nie zostały zaktualizowane");
        }


    }
}