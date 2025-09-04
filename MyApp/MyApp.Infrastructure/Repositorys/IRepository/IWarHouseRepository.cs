using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.IRepository
{
    public interface IWarHouseRepository
    {
        Task AddWarehouse(WarHouse ob1);
        Task<int> DeleteWarehouse(int id);
        Task<List<WarHouse>> GetAllWarehouses();
        Task<List<WareHouseStock>> GetAllWarehouseStocks();
    }
}
