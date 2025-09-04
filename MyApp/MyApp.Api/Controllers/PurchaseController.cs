using Inventory_Management_System.DTOs;
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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService; 
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        // add purchase
        [HttpPost("Items")]
        public async Task<IActionResult> Add([FromBody] PurchaseOrderItemDto PurchaseOrderItem)
        {
            var flag = await _purchaseService.PurchaseItem(PurchaseOrderItem);
            if (flag == 0)
            {
                return BadRequest("Not exist this supplier");
            }
            return Ok(PurchaseOrderItem);
        }
        // purchaseOrder
        [HttpGet("PendingOrders")]
        public async Task<IActionResult> GetAllPendingPurchaseOrder()
        {
            var PurchaseOrders = await _purchaseService.GetAllPurchaseOrders();
            if (PurchaseOrders.Any())
            {
                return Ok(PurchaseOrders);
            }
            return NotFound("No pending order found");
        }

        // approve of purchase_from_manager
        [HttpPost("ApproveOrder")]
        public async Task<IActionResult> ApprovePurchaseOrderByManager([FromBody] ManagerToWarhouseDto ManagerToWarHouse)
        {
            var Flag = await _purchaseService.ManagerToWarehouse(ManagerToWarHouse);
            return Ok(Flag);
        }
        // get purchase items by purchase order_id
        [HttpGet("{OrderId}/Items")]
        public async Task<IActionResult> GetPurchaseItem(int OrderId)
        {
            var PurchaseItem = await _purchaseService.GetPurchaseItems(OrderId);
            if (PurchaseItem.Any())
            {
                return Ok(PurchaseItem);

            }
            return NotFound("This purchase order doesn't exist in reality");
        }
    }
}
