using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using MyApp.Application.DTOs;
using MyApp.Application.Service_Layer.Service_Interface;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Application.Service_Layer.Service_Repostory
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository ProductRepository, IMapper mapper)
        {
            _productRepository = ProductRepository;
            _mapper = mapper;
        }

        // add product Brand
        public async Task AddBrand(BrandDto Brand)
        {
            var ProductBrand = _mapper.Map<Brand>(Brand);
            await _productRepository.AddBrand(ProductBrand);
        }
        // add product category
        public async Task AddCategory(CategoryDto Category)
        {
            //add product Category
            var ProductCategory = _mapper.Map<Category>(Category);
            await _productRepository.AddCategory(ProductCategory);
        }
        public async Task AddProduct(ProductDto Product)
        {
            //add product
            var MappedProduct = _mapper.Map<Product>(Product);
            await _productRepository.AddProduct(MappedProduct);    
        }

        // get by product ID
        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetProductById(Id);    
        }

        // get all 
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }
        // delete by Id
        public async Task<Product> DeleteProduct(int DeleteProduct)
        {
            return await _productRepository.DeleteProduct(DeleteProduct);             
        }
        // check brandId
        // Mamun
        //Nahid
        public async Task<int> CheckBrandId(int BrandId)
        {
            return await _productRepository.CheckBrandId(BrandId);
        }
        // check CategoryId
        public async Task<int> CheckCategoryId(int CategoryId)
        {
            return await _productRepository.CheckCategoryId(CategoryId);
        }        

    }
}
