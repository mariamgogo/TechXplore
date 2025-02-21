using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBank.Domain.Entities;

namespace MobileBank.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Identifier).IsUnique();
            builder.Property(x => x.Identifier).IsUnicode(false).HasMaxLength(11).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Age).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(12);

            builder.HasMany(x=>x.Accounts).WithOne(x=>x.Customer).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
