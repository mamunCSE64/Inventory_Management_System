using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Repositorys.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MyAppDbContext _context;        
        public PurchaseRepository( MyAppDbContext context)
        {
            _context = context;
        }
        // check supplierID exist or not
        public async Task<int> CheckSupplierID(int SupplierID)
        {
            var Supplier = await _context.Suppliers.FindAsync(SupplierID);
            if (Supplier is null)
            {
                return 0;
            }
            return 1;
        }
        // create purchase order Model
        public async Task CreatePurchaseOrder(PurchaseOrder PurchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(PurchaseOrder);
            await _context.SaveChangesAsync();

        }
        // send this order to the manager
        public async Task SendThisOrderToManager(Manager Manager)
        {
            await _context.Managers.AddAsync(Manager);
            await _context.SaveChangesAsync();

        }
        // add purchase_item       
        public async Task PurchaseItem(PurchaseItem PurchaseItems)
        {
            await _context.PurchaseItems.AddAsync(PurchaseItems);
            await _context.SaveChangesAsync();
        }
        // update Status,create warhouseStock,received product
        public async Task ManagerToWarehouse(WareHouseStock WarHouseStock)
        {
            await _context.WarehouseStocks.AddAsync(WarHouseStock);
            await _context.SaveChangesAsync();
        }
        // get purchase order
        public async Task<List<PurchaseOrder>> GetAllPurchaseOrders()
        {
            return await _context.PurchaseOrders
                .Where(p => p.Status == "pending")
                .OrderBy(p => p.Date)
                .ToListAsync();
        }
        // approve purchase order(from admin)
        public async Task ApprovePurchaseOrder(PurchaseOrder PurchaseOrder, int Id)
        {
            PurchaseOrder.Status = "approved";
            await _context.SaveChangesAsync();

            var PendingOrder = await _context.Managers
                        .FirstOrDefaultAsync(p => p.PurchaseOrderId == Id);
            PendingOrder.Status = "approved";
            PendingOrder.Date = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
        //check warhouseID
        public async Task<WarHouse> CheckWarHouseID(int warHouseID)
        {
            var WarHouse = await _context.Warhouses.FirstOrDefaultAsync(p => p.Id == warHouseID);
            return WarHouse;
        }

        //check purchaseOrderID
        public async Task<PurchaseOrder> CheckPurchaseOrderID(int PurchaseOrderID)
        {
            var PendingOrder = await _context.PurchaseOrders
                        .FirstOrDefaultAsync(p => p.Id == PurchaseOrderID);
            return PendingOrder;
        }
        // get purchase_items
        public async Task<List<PurchaseItem>> GetPurchaseItems(int PurchaseOrderID)
        {
            var Items = await _context.PurchaseItems
                .Where(p => p.PurchaseOrderId == PurchaseOrderID)
                .ToListAsync();
            return Items;
        }

    }
}
