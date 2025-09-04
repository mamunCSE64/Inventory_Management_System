using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Models;

namespace Inventory_Management_System.InheritDB
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SalerOrder> SalerOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WareHouseStock> WarehouseStocks { get; set; }
        public DbSet<WarHouse> Warhouses { get; set; }
        public DbSet<ReceivedProduct> ReceivedProducts { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<SaleableProduct> SaleablePoducts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
