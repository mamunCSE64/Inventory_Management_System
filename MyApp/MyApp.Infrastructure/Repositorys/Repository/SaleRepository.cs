using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MyAppDbContext _context;
        public SaleRepository(MyAppDbContext context)
        {
            _context = context;
        }
        // get purchase order
        public async Task<List<PurchaseOrder>> GetAllPurchaseOrders()
        {
            return await _context.PurchaseOrders
                .Where(p => p.Status == "pending")
                .OrderBy(p => p.Date)
                .ToListAsync();
        }
        //check purchaseOrderID
        public async Task<PurchaseOrder> CheckPurchaseOrderID(int PurchaseOrderID)
        {
            var PendingOrder = await _context.PurchaseOrders
                        .FirstOrDefaultAsync(p => p.Id == PurchaseOrderID);
            return PendingOrder;
        }
        // check warHouseID
        public async Task<WarHouse> CheckWarHouseID(int WarHouseID)
        {
            var WarHouse = await _context.Warhouses.FirstOrDefaultAsync(p => p.Id == WarHouseID);
            return WarHouse;
        }
        // approve purchase order(from admin)
        public async Task ApprovePurchaseOrder(PurchaseOrder PurchaseOrder,int Id)
        {
            PurchaseOrder.Status = "approved";
            await _context.SaveChangesAsync();

            var PendingOrder = await _context.Managers
                        .FirstOrDefaultAsync(p => p.PurchaseOrderId == Id);
            PendingOrder.Status = "approved";
            PendingOrder.Date = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
        // find warHouse stock Order
        public async Task<WareHouseStock> FindWarHouseStock(int Id)
        {
            return await _context.WarehouseStocks
                       .FirstOrDefaultAsync(p => p.Id == Id && p.Status == "pending");
        }
        // update Status,create warhouseStock,received product
        public async Task ManagerToWarehouse(WareHouseStock WareHouseStock)
        {
            await _context.WarehouseStocks.AddAsync(WareHouseStock);
            await _context.SaveChangesAsync();
        }
        
        //
        public async Task<SaleableProduct> CheckSaleableWarhousePoduct(int WarHouseID, int ProductId)
        {
            return await _context.SaleablePoducts
                  .FirstOrDefaultAsync(p => p.WarHouseId == WarHouseID && p.ProductId == ProductId);
        }
        // approve checkedItem
        public async Task ApproveCheckItem(WareHouseStock WareHouseStock)
        {
            WareHouseStock.Status = "approved";
            await _context.SaveChangesAsync();
        }
        // add to saleAble
        public async Task AddSaleableProduct(SaleableProduct Products)
        {
            await _context.SaleablePoducts.AddAsync(Products);
        }
        // add to the received items
        public async Task ReceiveStock(ReceivedProduct ReceivedProduct)
        {
            await _context.ReceivedProducts.AddAsync(ReceivedProduct);
            await _context.SaveChangesAsync();
        }
        // add saleAble
        public async Task UpdateToSaleAble()
        {
            await _context.SaveChangesAsync();
        }
        // create sellerOrder
        public async Task CreateSalerOrder(SalerOrder SalerOrder)
        {
            await _context.SalerOrders.AddAsync(SalerOrder);
            await _context.SaveChangesAsync();
        }
        // sale item/from customer
        public async Task SaleItem(SaleItem SaleItem)
        {
            await _context.SaleItems.AddAsync(SaleItem);
            await _context.SaveChangesAsync();

        }
        // get pending order from customer
        public async Task<List<SalerOrder>> GetPendingCustomerOrders()
        {
            return await _context.SalerOrders
                .Where(p => p.Status == "pending")
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }
        // approve pending order from customer
        public async Task<SalerOrder> ApproveCustomerOrder(int SellerId, int WarHouseId)
        {
            var SalerOrder = await _context.SalerOrders.FindAsync(SellerId);
            if (SalerOrder != null)
            {
                // item details
                var items = await _context.SaleItems
                    .Where(p => p.SalerOrderId == SellerId)
                    .ToListAsync();

                bool Flag = true;
                foreach (var it in items)
                {
                    var WarHouseItems = await _context.SaleablePoducts
                        .FirstOrDefaultAsync(p =>
                        p.WarHouseId == WarHouseId &&
                        p.ProductId == it.ProductId &&
                        it.Quantity <= p.Quantity);
                    if (WarHouseItems is null)
                    {
                        return null;
                    }
                }
                // send from the warHouse
                SalerOrder.WarHouseId = WarHouseId;
                SalerOrder.Status = "delivered";
                foreach (var Item in items)
                {
                    var ItemsWar = await _context.SaleablePoducts
                        .FirstOrDefaultAsync(p =>
                        p.WarHouseId == WarHouseId &&
                        p.ProductId == Item.ProductId);

                    ItemsWar.Quantity -= Item.Quantity;
                    await _context.SaveChangesAsync();
                }

            }
            return SalerOrder;
        }

    }
}
