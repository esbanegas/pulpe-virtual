using System.Collections;
using System.Collections.Generic;
using PulpeVirtual.Services.DataContext.Data;

namespace PulpeVirtual.Services.Features.Category
{
    public class Category : Entity
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product.Product> Products {get; set;}
    }
}