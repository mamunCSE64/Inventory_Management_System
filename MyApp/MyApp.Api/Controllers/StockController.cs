using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Application.Service_Layer.Service_Repostory;
using MyApp.Application.Services.ServiceInterfaces;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user,admin,author")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        // get stock by product ProductId
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetStockByProdId(int ProductId)
        {
            var ProductStock = await _stockService.GetStockByProductId(ProductId);
            if (ProductStock == -1)
            {
                return BadRequest("This product id doesn't exist");
            }
            return Ok(ProductStock);
        }
        // get_wireHouse wise product_items
        [HttpGet("{WarHouseId}/AllProduct")]
        public async Task<IActionResult> WareHouseWiseItems(int WarHouseId)
        {
            var Products = await _stockService.GetWarehouseWiseProducts(WarHouseId);
            if (!Products.Any())
            {
                return BadRequest("Not exist this wareHouse/anyProducts");
            }
            return Ok(Products);
        }
    }
}
