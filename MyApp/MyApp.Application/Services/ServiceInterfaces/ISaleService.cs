using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Service_Layer.Service_Interface
{
    public interface ISaleService
    {       
        Task<string> ReceiveStock(WarHouseStockOpenDto ob1);
        Task SaleItem(int id, List<OrderItemDto> OrderItems);
        Task<List<SalerOrder>> GetPendingCustomerOrders();
        Task<SalerOrder> ApproveCustomerOrder(int SalerId, int WarhouseId);
    }
}
