using FluentValidation;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Services.ServiceInterfaces;
using MyApp.Application.Validation;
// no more today
// icpc
namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "author")]

    public class ApplicationUserController : ControllerBase
    {
        public readonly IApplicationUserService _applicationUserService;   
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService; 
        }
        // add new Role
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddNewRole([FromBody] UserRoleDto UserRole)
        {
            var Check = new UserRoleValidator();
            var Result = Check.Validate(UserRole);
            if (!Result.IsValid)
            {
                return BadRequest(Result.Errors);
            }
            await _applicationUserService.AddUserRole(UserRole);
            return Ok(UserRole);
        }
        // add new User
        [HttpPost("Registration")]
        public async Task<IActionResult> AddNewUser([FromBody] UserDto User)
        {
            var Check = new UserValidator();
            var Result = Check.Validate(User);
            if (!Result.IsValid)
            {
                return BadRequest(Result.Errors);
            }
            var IsRoleExist = await _applicationUserService.CheckRoleID(User.UserRoleId);
            if(IsRoleExist == 0)
            {
                return NotFound("Not exist the Role");  
            }
            await _applicationUserService.AddUser(User);
            return Ok(User);
        }
        // get all User
        [HttpGet("All")]
        public async Task<IActionResult> GetAllUser()
        {
            var Users = await _applicationUserService.GetAllUser();
            if (!Users.Any())
            {
                return NotFound("No User found");
            }
            return Ok(Users);

        }
    }
}
