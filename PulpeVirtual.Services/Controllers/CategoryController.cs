using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PulpeVirtual.Services.Features.Category;

namespace PulpeVirtual.Services.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppService _categoryAppService;
        public CategoryController(CategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        public List<CategoryDto> GetCategories(){
            return _categoryAppService.GetCategories();
        }
    }
}