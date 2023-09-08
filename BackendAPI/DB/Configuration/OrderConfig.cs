using BackendAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendAPI.DB.Configuration
{
    public class OrderConfig
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerEmail).IsRequired();
            builder.Property(x => x.CustomerAddress).IsRequired();
            builder.Property(x => x.OrderPlacedTime).IsRequired();
        }
    }
}
