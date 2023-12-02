using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.User
{
    public class UserEfConfig : IEntityTypeConfiguration<Domain.Models.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.User.User> builder)
        {
            builder.Property(a => a.CellPhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x=>x.Password).IsRequired();
            builder.Property(x=>x.FullName).IsRequired();
            builder.HasQueryFilter(a => a.IsDeleted == false);

            builder.OwnsOne(x => x.Address, b =>
            {
                b.Property(x => x.FullAddress).IsRequired().HasMaxLength(500);
                b.Property(x => x.PostalCode).IsRequired().HasMaxLength(10);
            });
        }
    }
}
