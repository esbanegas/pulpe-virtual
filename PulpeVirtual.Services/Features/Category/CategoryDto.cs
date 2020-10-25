using System.Collections.Generic;
using PulpeVirtual.Services.Features.Product;

namespace PulpeVirtual.Services.Features.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}