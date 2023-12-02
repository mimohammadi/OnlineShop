using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration.Product
{
    public class ProductEfConfig : IEntityTypeConfiguration<Domain.Models.Product.Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Models.Product.Product> builder)
        {
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PackingMethod).IsRequired();
            builder.Property(x => x.Profit).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasQueryFilter(a => a.IsDeleted == false);
        }
    }
}
