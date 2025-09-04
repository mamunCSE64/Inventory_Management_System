using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.IRepository
{
    public interface ISaleRepository
    {

        //Task<PurchaseOrder> CheckPurchaseOrderID(int purchaseOrderID);
        Task<WarHouse> CheckWarHouseID(int warHouseID);        
        Task ManagerToWarehouse(WareHouseStock ob1);
        Task ApproveCheckItem(WareHouseStock ob1);
        Task<SaleableProduct> CheckSaleableWarhousePoduct(int warID,int prodID);
        Task AddSaleableProduct(SaleableProduct products);
        Task<WareHouseStock> FindWarHouseStock(int id);
        Task ReceiveStock(ReceivedProduct ob1);
        Task UpdateToSaleAble();
        Task CreateSalerOrder(SalerOrder ob1);
        Task SaleItem(SaleItem ob1);
        Task<List<SalerOrder>> GetPendingCustomerOrders();
        Task<SalerOrder> ApproveCustomerOrder(int sellerId, int warId);
    }
}
