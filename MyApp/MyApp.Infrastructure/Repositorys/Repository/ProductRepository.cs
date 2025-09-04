using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyAppDbContext _context;
        public ProductRepository(MyAppDbContext context)
        {
            _context = context;
        }

        // add brand
        public async Task AddBrand(Brand Brand)
        {
            Brand.Name = Brand.Name.ToLower();
            var Flag = await _context.Brands.FirstOrDefaultAsync(p => p.Name == Brand.Name);
            if (Flag is null)
            {
                await _context.Brands.AddAsync(Brand);
                await _context.SaveChangesAsync();
            }

        }
        // add category
        public async Task AddCategory(Category Category)
        {
            Category.Name = Category.Name.ToLower();
            var Flag = await _context.Categorys.FirstOrDefaultAsync(p => p.Name == Category.Name);
            if(Flag is null)
            {
                await _context.Categorys.AddAsync(Category);
                await _context.SaveChangesAsync();
            }
            
        }
       
        // add product
        public async Task AddProduct(Product Product)
        {
            var Flag = await _context.Products.FirstOrDefaultAsync(p => p.Name == Product.Name);
            if(Flag is null)
            {
                await _context.Products.AddAsync(Product);
                await _context.SaveChangesAsync();
            }
        }
        // gey product by ID
        public async Task<Product> GetProductById(int Id)

        {
            return await _context.Products.FindAsync(Id);
        }
        // get all 
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        // delete by Id
        public async Task<Product> DeleteProduct(int Id)
        {
            var Product = await _context.Products.FindAsync(Id);
            if (Product is not null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }
            return Product;
        }
        // check BrandId
        public async Task<int> CheckBrandId(int BrandId)
        {
            var Flag = await _context.Brands.FindAsync(BrandId);
            if (Flag is null) return 0;
            return 1;
        }
        // check productId
        public async Task<int> CheckCategoryId(int CategoryId)
        {
            var Flag = await _context.Categorys.FindAsync(CategoryId);
            if (Flag is null) return 0;
            return 1;
        }
    }
}
