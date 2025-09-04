using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositorys.IRepository
{
    public interface IProductRepository
    {
        Task AddCategory(Category ob1);
        Task AddBrand(Brand ob1);
        Task AddProduct(Product ob1);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> DeleteProduct(int id);
        Task<int> CheckBrandId(int brandId);
        Task<int> CheckCategoryId(int categoryId);
    }
}
