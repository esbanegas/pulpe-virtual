using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PulpeVirtual.Services.DataContext.Data;
using PulpeVirtual.Services.Features.Product;

namespace PulpeVirtual.Services.DataContext.Maps
{
    public class ProductMap : EntityMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");
            builder.HasKey(t => t.ProductId);

            builder.Property(t => t.ProductId).HasColumnName("ProductId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(t => t.CategoryId).HasColumnName("CategoryId").HasColumnType("int").IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasColumnType("Varchar(100)").IsRequired().IsUnicode(false);
            builder.Property(t => t.Coin).HasColumnName("Coin").HasColumnType("Varchar(5)").IsRequired().IsUnicode(false);
            builder.Property(t => t.Price).HasColumnName("Price").HasColumnType("Decimal(5,2) ").IsRequired();
            builder.Property(t => t.Quantity).HasColumnName("Quantity").HasColumnType("int").IsRequired();
            builder.Property(t => t.PathImg).HasColumnName("PathImg").HasColumnType("Varchar(200)").IsRequired().IsUnicode(false);

            builder.HasOne(t => t.Category).WithMany(t => t.Products).HasForeignKey(t => t.CategoryId);
        }
    }
}