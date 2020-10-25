using PulpeVirtual.Services.DataContext.Data;

namespace PulpeVirtual.Services.Features.Product
{
    public class Product : Entity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Coin { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PathImg { get; set; }

        public virtual Category.Category Category {get; set;}
    }
}