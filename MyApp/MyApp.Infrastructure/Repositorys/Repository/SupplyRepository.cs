using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly MyAppDbContext _context;
        public SupplyRepository(MyAppDbContext context)
        {
            _context = context;
        }       
       
        public async Task AddSupplier(Supplier Supplier)
        {
            await _context.Suppliers.AddAsync(Supplier);
            await _context.SaveChangesAsync();

        }
        // get all supplier
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

    }
}
