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
    public class StockRepository : IStockRepository
    {
        public readonly MyAppDbContext _context;
        public StockRepository(MyAppDbContext context)
        {
            _context = context;
        }

        // get product stock
        public async Task<int> GetStockByProductId1(int Id)
        {
            var Flag = await _context.Products.FindAsync(Id);
            if (Flag is null) return -1;
            return await _context.SaleablePoducts
                .Where(p => p.ProductId == Id)
                .SumAsync(p => p.Quantity);

        }
        public async Task<List<SaleableProduct>> GetWarehouseWiseProducts(int WarHouseId)
        {
            var Products = await _context.SaleablePoducts
                .Where(p => p.WarHouseId == WarHouseId)
                .ToListAsync();

            return Products;
        }
    }
}
