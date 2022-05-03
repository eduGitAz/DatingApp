using System.Collections.Generic;
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
        public CompaniesController(ICompanyRepository comapnyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _comapnyRepository = comapnyRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _comapnyRepository.GetCompaniesDtoAsync();

            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            return await _comapnyRepository.GetCompanyDtoByIdAsync(id);

        }


    }
}