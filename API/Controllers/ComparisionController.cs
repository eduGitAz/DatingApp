using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ComparisionController: BaseApiController
    {
        private readonly IComparisionRepository _comparasionRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public ComparisionController(IComparisionRepository comparasionRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _comparasionRepository = comparasionRepository;
            _userRepository = userRepository;
        }
        [Authorize(Policy = "RequireManagerRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppComparision>>> GetComparision()
        {

            var comparisions = await _comparasionRepository.GetComparision();
            return Ok(comparisions);
       
        } 

    }
}