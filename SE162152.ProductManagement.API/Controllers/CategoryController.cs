using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SE162152.ProductManagement.API.Contracts.Requests;
using SE162152.ProductManagement.API.Services.Implementation;
using SE162152.ProductManagement.API.Services.Interface;
using SE162152.ProductManagement.Repo.Entity;

namespace SE162152.ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            try
            {
                var category = _categoryService.GetCategories();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult SaveCategory([FromBody] CreateCategoryRequest categories)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = categories.CategoryName,
                  
                };

                // Ensure the CategoryId is not set by the client
                _categoryService.SaveCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
