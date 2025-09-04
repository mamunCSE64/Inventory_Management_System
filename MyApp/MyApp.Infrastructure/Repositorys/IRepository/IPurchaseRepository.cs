using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.IRepository
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseOrder>> GetAllPurchaseOrders();
        Task ApprovePurchaseOrder(PurchaseOrder ob1, int id);
        Task<PurchaseOrder> CheckPurchaseOrderID(int purchaseOrderId);
        Task<WarHouse> CheckWarHouseID(int warHouseID);
        Task ManagerToWarehouse(WareHouseStock warhouse);
        Task<int> CheckSupplierID(int supplierID);
        Task CreatePurchaseOrder(PurchaseOrder ob1);
        Task SendThisOrderToManager(Manager ob1);
        Task PurchaseItem(PurchaseItem ob1);
        Task<List<PurchaseItem>> GetPurchaseItems(int purchaseOrder_ID);
    }
}
