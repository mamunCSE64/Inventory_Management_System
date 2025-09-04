using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task<string> ManagerToWarehouse(ManagerToWarhouseDto ob1);
        Task<List<PurchaseOrder>> GetAllPurchaseOrders();
        Task<int> PurchaseItem(PurchaseOrderItemDto PurchaseOrderItem);
        Task<List<PurchaseItem>> GetPurchaseItems(int PurchaseOrderId);
    }
}
