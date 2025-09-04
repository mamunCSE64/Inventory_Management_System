using Inventory_Management_System.DTOs;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Service_Layer;
using MyApp.Application.Service_Layer.Service_Interface;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user,admin,author")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // add product Brand
        [HttpPost("AddBrand")]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto ProductBrand)
        {
            await _productService.AddBrand(ProductBrand);
            return Ok(ProductBrand);
        }
        // add product category
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto ProductCategory)
        {
            await _productService.AddCategory(ProductCategory);
            return Ok(ProductCategory);
        }
        // add product
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto Product)
        {
            var Flag1 = await _productService.CheckBrandId(Product.BrandId);
            var Flag2 = await _productService.CheckCategoryId(Product.CategoryId);

            if (Flag1+Flag2 < 2 )
            {
                return BadRequest("BrandId/CategoryId doesn't exist");
            }

            await _productService.AddProduct(Product);
            return Ok(Product);
        }
        // get by Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var Product = await _productService.GetProductById(Id);
            if (Product != null)
            {
                return Ok(Product);
            }
            return NotFound("Product not found");
        }
        // get all 
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var AllProduct = await _productService.GetAllProducts();
            if (AllProduct.Any())
            {
                return Ok(AllProduct);
            }
            return NotFound("No records found");
        }
        // Delete any product's by ID
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var DeleteProduct = await _productService.DeleteProduct(Id);
            if (DeleteProduct != null)
            {
                return Ok(DeleteProduct);
            }
            return BadRequest("This product not found");
        }
    }
}
