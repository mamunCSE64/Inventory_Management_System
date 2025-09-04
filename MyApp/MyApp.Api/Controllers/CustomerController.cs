using Inventory_Management_System.DTOs;
using Inventory_Management_System.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service_Layer;
using MyApp.Application.Service_Layer.Service_Interface;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user,admin,author")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService; 
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // add new customer
        [HttpPost("Registration")]
        public async Task<IActionResult> AddNewCustomer([FromBody] CustomerDto Customer)
        {
            var check = new CustomerValidator();
            var Result = check.Validate(Customer);
            if (!Result.IsValid)
            {
                return BadRequest(Result.Errors);
            }
            await _customerService.AddCustomer(Customer);
            return Ok(Customer);
        }        
        // get all customer
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var Customers = await _customerService.GetAllCustomers();
            if (Customers.Any())
            {
                return Ok(Customers);
            }
            return NotFound("No customer found");
        }
    }
}
