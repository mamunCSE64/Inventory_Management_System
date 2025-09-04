using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Service_Layer.Service_Interface
{
    public interface IWarhouseService
    {
        Task<int> Deletewarhouse(int id);
        Task<List<WarHouse>> GetAllWarehouses();
        Task AddWarehouse(WarhouseDto Warhouse);
        Task<List<WareHouseStock>> GetAllWarehouseStocks();
    }
}
