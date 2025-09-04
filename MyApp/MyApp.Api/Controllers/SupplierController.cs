using Inventory_Management_System.DTOs;
using Inventory_Management_System.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service_Layer;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Application.Service_Layer.Service_Repostory;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user,admin,author")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplyService _supplyService;
        public SupplierController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }
        //add new supplier
        [HttpPost("Registration")]
        public async Task<IActionResult> AddNewSupplier([FromBody] SupplierDto Supplier)
        {
            var Check = new SupplierValidator();
            var Result = Check.Validate(Supplier);
            if (!Result.IsValid)
            {
                return BadRequest(Result.Errors);
            }
            await _supplyService.AddSupplier(Supplier);
            return Ok(Supplier);
        }
       
        // get all supplier
        [HttpGet("All")]
        public async Task<IActionResult> GetAllSupplier()
        {
            var AllSupplier = await _supplyService.GetAllSuppliers();
            if (AllSupplier.Any())
            {
                return Ok(AllSupplier);
            }
            return NotFound("No supplier found");
        }
    }
}
