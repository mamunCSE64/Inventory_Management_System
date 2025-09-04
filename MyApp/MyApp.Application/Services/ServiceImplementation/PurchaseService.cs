using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.Services.ServiceInterfaces;
using MyApp.Infrastructure.Repositorys.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceInterfaces
{
    public class PurchaseService : IPurchaseService
    {
        public readonly IPurchaseRepository _purchaseRepository;
        public readonly IMapper _mapper;
        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper)    
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }
        // get purchase Item by purchase order_id
        public async Task<List<PurchaseItem>> GetPurchaseItems(int PurchaseOrderId)
        {
            return await _purchaseRepository.GetPurchaseItems(PurchaseOrderId);
        }
        // get purchase order
        public async Task<List<PurchaseOrder>> GetAllPurchaseOrders()
        {
            return await _purchaseRepository.GetAllPurchaseOrders();
        }
        // add purchase_item
        public async Task<int> PurchaseItem(PurchaseOrderItemDto PurchaseOrderItem)
        {
            var Supplier = await _purchaseRepository.CheckSupplierID(PurchaseOrderItem.SupplierId);
            if (Supplier == 0)
            {
                return 0;
            }
            // create purchase_order
            var PurchaseOrder = _mapper.Map<PurchaseOrder>(PurchaseOrderItem);
            await _purchaseRepository.CreatePurchaseOrder(PurchaseOrder);

            // send this order to the managere_1
            var Manager = new Manager();
            Manager.PurchaseOrderId = PurchaseOrder.Id;
            await _purchaseRepository.SendThisOrderToManager(Manager);

            // create the purchase_item
            foreach (var ProdutcDetails in PurchaseOrderItem.OrderItems)
            {
                var ProductDetails = new PurchaseItem
                {
                    PurchaseOrderId = PurchaseOrder.Id,
                    ProductId = ProdutcDetails.ProductId,
                    Quantity = ProdutcDetails.Quantity
                };
                await _purchaseRepository.PurchaseItem(ProductDetails);

            }
            return 1;

        }

        // update Status,create warhouseStock,received product
        public async Task<string> ManagerToWarehouse(ManagerToWarhouseDto ManagerToWarhouse)
        {
            var PendingOrder = await _purchaseRepository.CheckPurchaseOrderID(ManagerToWarhouse.PurchaseOrderId);
            var warHouse = await _purchaseRepository.CheckWarHouseID(ManagerToWarhouse.WarHouseId);


            if (PendingOrder is null && warHouse is null)
            {
                return "Purchase OrderId or WarHouseId not exist";
            }

            // approve order by manager            
            await _purchaseRepository.ApprovePurchaseOrder(PendingOrder, ManagerToWarhouse.PurchaseOrderId);

            // war house update
            var Warhouse = new WareHouseStock();
            Warhouse.WarHouseID = ManagerToWarhouse.WarHouseId;
            Warhouse.PurchaseOrderID = ManagerToWarhouse.PurchaseOrderId;
            Warhouse.Status = "pending";
            await _purchaseRepository.ManagerToWarehouse(Warhouse);

            return "Approved and send to the wareHouse";
        }
        public async Task<PurchaseOrder> CheckPurchaseOrderID(int PurchaseOrderId)
        {
            return await _purchaseRepository.CheckPurchaseOrderID(PurchaseOrderId);
        }
    }
}
