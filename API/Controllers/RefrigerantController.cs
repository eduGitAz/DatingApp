using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RefrigerantController: BaseApiController
    {
        private readonly IRefrigerantRepository _refrigerantRepository;
        private readonly IMapper _mapper;

        public RefrigerantController(IRefrigerantRepository refrigerantRepository, IMapper mapper)
        {
            _mapper = mapper;
            _refrigerantRepository = refrigerantRepository;
        }

        [Authorize(Policy = "RequireInstallerRole")]
        public async Task<ActionResult<IEnumerable<RefrigerantDto>>> GetRefrigerantDto()
        {
        
            var refrigerantDtos = await _refrigerantRepository.GetRefrigerantDtoAsync();

            return Ok(refrigerantDtos);
        } 
    }
}