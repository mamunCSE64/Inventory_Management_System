using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class WarHouseRepository : IWarHouseRepository
    {
        private readonly MyAppDbContext _context;
        public WarHouseRepository(MyAppDbContext context)
        {
            _context = context;
        }
        // add warhouse
        public async Task AddWarehouse(WarHouse Warhouse)
        {
            await _context.Warhouses.AddAsync(Warhouse);
            await _context.SaveChangesAsync();

        }
        // delete warhouse
        public async Task<int> DeleteWarehouse(int Id)
        {
            var WarHouse = await _context.Warhouses.FindAsync(Id);
            if (WarHouse is not null)
            {
                _context.Warhouses.Remove(WarHouse);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        // get all warhouse
        public async Task<List<WarHouse>> GetAllWarehouses()
        {
            return await _context.Warhouses.ToListAsync();
        }
        
        // warhouse_stock
        public async Task<List<WareHouseStock>> GetAllWarehouseStocks()
        {
            return await _context.WarehouseStocks
                .Where(p => p.Status == "Pending")
                .ToListAsync();
        }
    }
}
