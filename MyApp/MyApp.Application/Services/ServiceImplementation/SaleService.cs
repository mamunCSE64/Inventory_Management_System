using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.DTOs;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Application.Service_Layer.Service_Repostory
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository managerRepository)
        {
            _saleRepository = managerRepository;
             
        }
        
        // add to the saleable items
        public async Task<string> ReceiveStock(WarHouseStockOpenDto WarhouseStock)
        {
            var Warhouse = await _saleRepository.FindWarHouseStock(WarhouseStock.WarHouseStockId);
            if (Warhouse is null)
            {
                return "This wareHouse stock_id not exist or already received";
            }

            await _saleRepository.ApproveCheckItem(Warhouse);

            foreach (var Items in WarhouseStock.CheckProduct)
            {
                // add product to the received product
                var ReceivedProduct = new ReceivedProduct();
                ReceivedProduct.WarHouseStockId = WarhouseStock.WarHouseStockId;
                ReceivedProduct.ProductId = Items.ProductId;
                ReceivedProduct.Good = Items.Good;
                ReceivedProduct.Bad = Items.Damage;
                ReceivedProduct.Missing = Items.Missing;
                await _saleRepository.ReceiveStock(ReceivedProduct);

                // add to the saleable product 
                var ExistingProduct = await _saleRepository.CheckSaleableWarhousePoduct(Warhouse.WarHouseID,Items.ProductId); 
                     
                if (ExistingProduct is null)
                {
                    var ProductId = new SaleableProduct();
                    ProductId.ProductId = Items.ProductId;
                    ProductId.Quantity += Items.Good;
                    ProductId.WarHouseId = Warhouse.WarHouseID;
                    await _saleRepository.AddSaleableProduct(ProductId);                      
                }
                else
                {
                    ExistingProduct.Quantity += Items.Good;
                }
                await _saleRepository.UpdateToSaleAble();
            }
            return "Received products of this warHouse stock_id";
        }
        // sale Item/from customer
        public async Task SaleItem(int Id, List<OrderItemDto> OrderItems)
        {
            // add to the saler order
            var SalerOrder = new SalerOrder();
            SalerOrder.CustomerId = Id;
            await _saleRepository.CreateSalerOrder(SalerOrder);

            // add to the sale-Item
            foreach (var Items in OrderItems)
            {
                var SaleItem = new SaleItem();
                SaleItem.SalerOrderId = SalerOrder.Id;
                SaleItem.ProductId = Items.ProductId;
                SaleItem.Quantity = Items.Quantity;
                await _saleRepository.SaleItem(SaleItem);
            }
        }
        // get pending order from customer
        public async Task<List<SalerOrder>> GetPendingCustomerOrders()
        {
            return await _saleRepository.GetPendingCustomerOrders();
        }
        // approve pending order from customer
        public async Task<SalerOrder> ApproveCustomerOrder(int SalerId, int WarhouseId)
        {
            return await _saleRepository.ApproveCustomerOrder(SalerId, WarhouseId);
        }

    }
}
