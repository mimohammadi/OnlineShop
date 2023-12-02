using Domain.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Order
{
    public class OrderItemEfConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(a => a.OrderId).IsRequired();
            builder.Property(a => a.ProductId).IsRequired();
            builder.Property(a => a.Price).IsRequired();
            builder.Property(a => a.Quantity).IsRequired();
            builder.HasQueryFilter(a => a.IsDeleted == false);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
