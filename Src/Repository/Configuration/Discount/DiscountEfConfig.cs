using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Discount
{
    public class DiscountEfConfig : IEntityTypeConfiguration<Domain.Models.Discount.Discount>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Discount.Discount> builder)
        {
            builder.Property(a => a.Type).IsRequired();
            builder.Property(a => a.Code).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Value).IsRequired();
            builder.HasQueryFilter(a => a.IsDeleted == false);

            
        }
    }
}
