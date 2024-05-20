using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE162152.ProductManagement.API.Contracts.Requests;
using SE162152.ProductManagement.API.Services.Interface;
using SE162152.ProductManagement.Repo.Entity;

namespace SE162152.ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts() 
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) 
            {
            try
            {
                var product = _productService.FindProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult SaveProduct([FromBody] CreateProductRequest products)
        {
            try
            {
                var product = new Product
                {
                    ProductName = products.ProductName,
                    CategoryId = products.CategoryId,
                    UnitsInStock = products.UnitsInStock,
                    UnitPrice = products.UnitPrice
                };
                _productService.SaveProduct(product);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductRequest products) 
        {
            try
            {
                var existingProduct = _productService.FindProductById(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }
                existingProduct.ProductName = products.ProductName;
                existingProduct.CategoryId = products.CategoryId;
                existingProduct.UnitsInStock = products.UnitsInStock;
                existingProduct.UnitPrice = products.UnitPrice;

                _productService.UpdateProduct(existingProduct);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id) 
        {
            try
            {
                var existingProduct = _productService.FindProductById(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }
                _productService.DeleteProduct(existingProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
