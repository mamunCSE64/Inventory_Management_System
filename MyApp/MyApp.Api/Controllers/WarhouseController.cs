using Inventory_Management_System.DTOs;
using Inventory_Management_System.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Application.Service_Layer.Service_Repostory;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user,admin,author")]
    public class WarhouseController : ControllerBase
    {
        private readonly IWarhouseService _warhouseService;
        public WarhouseController(IWarhouseService warHouseService)
        {
            _warhouseService = warHouseService;
        }
        
        // add new warhouse
        [HttpPost("Registration")]
        public async Task<IActionResult> AddNewWareHouse([FromBody] WarhouseDto Warhouse)
        {
            var Check = new WarHouseValidator();
            var Result = Check.Validate(Warhouse);
            if (!Result.IsValid)
            {
                return BadRequest(Result.Errors);
            }
            await _warhouseService.AddWarehouse(Warhouse);
            return Ok(Warhouse);
        }

        // delete warhouse
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteWarHouse(int Id)
        {
            var Flag = await _warhouseService.Deletewarhouse(Id);
            if(Flag == 1)
            {
                return Ok("Deleted this warHouse successfully");
            }
            return BadRequest("WareHouse not found with this Id");
        }
        // get all warhouse
        [HttpGet("All")]
        public async Task<IActionResult> GetAllWareHous()
        {
            var AllWarHouse = await _warhouseService.GetAllWarehouses();
            if (AllWarHouse.Any())
            {
                return Ok(AllWarHouse);
            }
            return NotFound("No wareHouse found");
        }
        // warhouse_stock
        [HttpGet("UnCheckedItems")]
        public async Task<IActionResult> GetAllUncheckStock()
        {
            var UncheckWarHouseStock = await _warhouseService.GetAllWarehouseStocks();
            if (UncheckWarHouseStock.Any())
            {
                return Ok(UncheckWarHouseStock);
            }
            return NotFound("Not pending any stock");
        }

    }
}
