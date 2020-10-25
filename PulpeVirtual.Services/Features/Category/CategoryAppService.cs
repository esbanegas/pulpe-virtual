using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PulpeVirtual.Services.DataContext;
using PulpeVirtual.Services.Features.Product;

namespace PulpeVirtual.Services.Features.Category
{
    public class CategoryAppService
    {
        private readonly PulpeVirtualDataContext _pulpeVirtualDataContext;

        public CategoryAppService(PulpeVirtualDataContext pulpeVirtualDataContext)
        {
            _pulpeVirtualDataContext = pulpeVirtualDataContext;
        }

        public List<CategoryDto> GetCategories(){
            IEnumerable<Category> categories = _pulpeVirtualDataContext.Categories.ToList();

            return  BuildCategoryDto(categories);
        }

        private List<CategoryDto> BuildCategoryDto(IEnumerable<Category> categories){
            return categories.Select(t => new CategoryDto {
                CategoryId = t.CategoryId,
                Description = t.Description,
                Products = ProductDto.From(t.Products)
            }).ToList();
        }
    }
}