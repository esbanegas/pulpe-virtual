using System.Collections.Generic;
using System.Linq;
using PulpeVirtual.Services.DataContext;
using PulpeVirtual.Services.Features.Category;
using PulpeVirtual.Services.Features.Product;

namespace PulpeVirtual.Services
{
    public static class DbInitialize
    {
        public static void Initialize(PulpeVirtualDataContext context){
            context.Database.EnsureCreated();

            if(context.Categories.Any()){
                return;
            }

            List<Category> categories = new List<Category> {
                new Category {
                    Description = "Carnes",
                    Products = new List<Product>{
                    new Product {
                        Description = "CARNE DE RES BISTEC LIBRA",
                        Coin = "HNL",
                        Price = 78.00M,
                        Quantity = 100,
                        PathImg = "./img/carne.jpg"
                    },
                    new Product {
                        Description = "CARNE DE RES MANO DE PIEDRA LIBRA",
                        Coin = "HNL",
                        Price = 70.00M,
                        Quantity = 50,
                        PathImg = "./img/carne1.jpg"
                    }
                 }
                },
                new Category {
                    Description = "Bebidas",
                    Products = new List<Product>{
                    new Product {
                        Description = "7UP 3 LITROS HNL48.00",
                        Coin = "HNL",
                        Price = 49.00M,
                        Quantity = 50,
                        PathImg = "./img/bebida.jpg"
                    },
                    new Product {
                        Description = "7UP 500 ML",
                        Coin = "HNL",
                        Price = 16.00M,
                        Quantity = 30,
                        PathImg = "./img/bebida1.jpg"
                    }
                 }
                }
            };

            foreach(Category category in categories){
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }
    }
}