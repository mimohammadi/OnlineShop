using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Order
{
    public class OrderEfConfig : IEntityTypeConfiguration<Domain.Models.Order.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Order.Order> builder)
        {
            builder.Property(a => a.Sattus).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.TotalPrice).IsRequired();
            builder.HasQueryFilter(a => a.IsDeleted == false);

            builder.HasOne(x => x.User)
               .WithMany(x => x.Orders)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Items)
               .WithOne(d => d.Order)
               .HasForeignKey(d => d.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
