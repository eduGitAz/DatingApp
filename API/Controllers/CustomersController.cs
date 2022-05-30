using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  
    public class CustomersController : BaseApiController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        public CustomersController(ICustomerRepository customerRepository, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var customers = await _customerRepository.GetCustomersDtoAsync(id);

            return Ok(customers);
        } 
        
        [HttpGet("count")]
        
        public async Task<ActionResult<IEnumerable<int>>> CountCustomers()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
            
            int id = currentUser.AppCompany.Id;
            var customers = await _customerRepository.GetCustomersDtoAsync(id);
            int i = 0;
            foreach (var item in customers)
            {
                i++;
            }

            return Ok(i);
        } 
   
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomerDtoByIdAsync(id);

        } 

        [HttpPost("add")] 
         public async Task<ActionResult> AddCustomer(CustomerDto customerDto)
        {

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var currentUser = await _userRepository.GetUserByIdAsync(currentUserId);
          

            AppCustomer customer = new AppCustomer{
                Name = customerDto.Name,
                Surname = customerDto.Surname,
                StreetNumber = customerDto.StreetNumber,
                City = customerDto.City,
                PostCode = customerDto.PostCode,
                PhoneNumber = customerDto.PhoneNumber,
                AppCompany = currentUser.AppCompany
            }; 

            
            var result = await _customerRepository.Add(customer);
           
            return Ok(); 
        }
         
         [HttpPut("{id}")] 
         public async Task<ActionResult> UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)  
        {
    
           var customer = await _customerRepository.GetCustomerByIdAsync(id);
            _mapper.Map(customerUpdateDto, customer);
            _customerRepository.Update(customer);
            

            if (await _customerRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Dane nie zostały zaktualizowane");
        }
       
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer(int id)
        {
            await _customerRepository.Delete(id);
            return NoContent();
        }

     
    }
}