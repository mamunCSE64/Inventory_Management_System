using Inventory_Management_System.DTOs;
using Inventory_Management_System.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApp.Application.Service_Layer;
using MyApp.Application.Service_Layer.Service_Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IConfiguration _configuration;
        public AuthorController(IAuthorService authorService, IConfiguration configuration)
        {
            _authorService = authorService;
            _configuration = configuration;
        }
         
        // LogIn for authentication & authorization
        [HttpPost("LogIn")]
        public async Task<IActionResult> Login([FromBody] LogInCredentialDto User)
        {
            if (User is null)
            {
                return BadRequest("should input the valid data");
            }
            // CheckProduct user credentials
            if ((User.UserName == "admin" && User.Password == "admin123") ||
                (User.UserName == "user" && User.Password == "user123") ||
                (User.UserName == "author" && User.Password == "author123"))
            {
                // Generate token
                var token = GenerateToken(User);

                return Ok(new { token });
            }
            return BadRequest("UnAuthorized (invalid userName or password) ");

        }         

      
        private string GenerateToken(LogInCredentialDto User)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            string role;
            if (User.UserName == "admin")
                role = "admin";
            else if (User.UserName == "author")
                role = "author";
            else
                role = "user";  

            var claims = new List<Claim>{
                new Claim(ClaimTypes.Role, role)
            };


            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
