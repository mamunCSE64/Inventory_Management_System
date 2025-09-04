using Inventory_Management_System.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.ServiceInterfaces
{
    public interface IStockService
    {
        Task<int> GetStockByProductId(int Id);
        Task<List<ProductStockDto>> GetWarehouseWiseProducts(int WarhouseId);
    }
}
