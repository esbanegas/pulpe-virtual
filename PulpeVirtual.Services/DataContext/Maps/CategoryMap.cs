using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PulpeVirtual.Services.DataContext.Data;
using PulpeVirtual.Services.Features.Category;

namespace PulpeVirtual.Services.DataContext.Maps
{
    public class CategoryMap : EntityMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo");
            builder.HasKey(t => t.CategoryId);

            builder.Property(t => t.CategoryId).HasColumnName("CategoryId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(t => t.Description).HasColumnName("Description").HasColumnType("Varchar(100)").IsRequired().IsUnicode(false);
        }
    }
}