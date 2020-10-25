using System.Collections.Generic;
using System.Linq;

namespace PulpeVirtual.Services.Features.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Coin { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PathImg { get; set; }

        internal static List<ProductDto> From(ICollection<Product> products){
            return products.Select(t => new ProductDto {
                ProductId = t.ProductId,
                CategoryId = t.CategoryId,
                Description = t.Description,
                Coin = t.Coin,
                Price = t.Price,
                Quantity = t.Quantity,
                PathImg = t.PathImg
            }).ToList();
        }
    }
}