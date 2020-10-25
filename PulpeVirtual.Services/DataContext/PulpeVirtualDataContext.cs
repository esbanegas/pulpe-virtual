using Microsoft.EntityFrameworkCore;
using PulpeVirtual.Services.DataContext.Maps;
using PulpeVirtual.Services.Features.Category;
using PulpeVirtual.Services.Features.Product;

namespace PulpeVirtual.Services.DataContext
{
    public class PulpeVirtualDataContext : DbContext
    {
        public PulpeVirtualDataContext(DbContextOptions<PulpeVirtualDataContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}