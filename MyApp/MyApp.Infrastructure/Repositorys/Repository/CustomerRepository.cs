using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyAppDbContext _context;
        public CustomerRepository(MyAppDbContext context)
        {
            _context = context;
        }
        // add Addcustomer
        public async Task AddCustomer(Customer Customer)
        {
            await _context.Customers.AddAsync(Customer);
            await _context.SaveChangesAsync();

        }          
         
        // get all customer
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
