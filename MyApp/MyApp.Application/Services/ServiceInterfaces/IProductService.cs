using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Service_Layer.Service_Interface
{
    public interface IProductService
    {
        Task AddProduct(ProductDto ob1);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> DeleteProduct(int id);
        Task AddCategory(CategoryDto ob1);
        Task AddBrand(BrandDto ob1);
        Task<int> CheckBrandId(int brandId);
        Task<int> CheckCategoryId(int categoryId);
    }
}
