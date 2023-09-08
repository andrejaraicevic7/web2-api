using BackendAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.DB.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Seller).IsRequired();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}
