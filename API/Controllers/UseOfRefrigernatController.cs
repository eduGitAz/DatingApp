using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UseOfRefrigernatController: BaseApiController
    {
        private readonly IUseOfRefrigernatRepository _useOfRefrigernatRepository;
        private readonly IMapper _mapper;

        public UseOfRefrigernatController(IUseOfRefrigernatRepository useOfRefrigernatRepository, IMapper mapper)
        {
            _mapper = mapper;
            _useOfRefrigernatRepository = useOfRefrigernatRepository;
        }
        
        [Authorize(Policy = "RequireInstallerRole")]
        public async Task<ActionResult<IEnumerable<UseOfRefrigernatDto>>> GetUseOfRefrigernatDtoAsync()
        {
        
            var useOfRefrigernatDtoAsync = await _useOfRefrigernatRepository.GetUseOfRefrigernatDtoAsync();

            return Ok(useOfRefrigernatDtoAsync);
        } 
    }
}