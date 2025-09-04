using Inventory_Management_System.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Service_Layer;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Application.Service_Layer.Service_Repostory;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user,admin,author")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        
        // add product to the saleable item
        [HttpPost("AddSaleAbleProducts")]
        public async Task<IActionResult> ReceivedStocByManager([FromBody] WarHouseStockOpenDto WarHouseStockOpen)
        {
            var Flag = await _saleService.ReceiveStock(WarHouseStockOpen);
            return Ok(Flag);
        }
        //create sale order
        [HttpPost("Items")]
        public async Task<IActionResult> Add([FromBody] CreateSaleOrderDto CreateSaleOrder)
        {
            await _saleService.SaleItem(CreateSaleOrder.CustomerId, CreateSaleOrder.Items);
            return Ok(CreateSaleOrder.Items);
        }
        // see all the order from customer
        [HttpGet("PendingOrders")]
        public async Task<IActionResult> GetAllOrder()
        {
            var PendingOrder = await _saleService.GetPendingCustomerOrders();
            if (!PendingOrder.Any())
            {
                return BadRequest("No pending request");
            }
            return Ok(PendingOrder);
        }
        // approve pending order from customer
        [HttpPost("ApproveOrder")]
        public async Task<IActionResult> ApprovePendingOrder([FromBody] ApproveSaleOrderDto ApproveSaleOrder)
        {
            var PendingOrders = await _saleService.ApproveCustomerOrder(ApproveSaleOrder.SellerOrderId, ApproveSaleOrder.WarhouseId);
            if (PendingOrders is null)
            {
                return BadRequest("Insufficient of quantity or Invalid sellerOrderID");
            }
            return Ok(PendingOrders);
        }

    }
}
