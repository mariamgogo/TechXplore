using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBank.Domain.Entities;

namespace MobileBank.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.AccountNumber).IsUnique();
            builder.Property(x => x.AccountNumber).IsRequired().IsUnicode(false);
            builder.Property(x => x.Currency).IsRequired().IsUnicode(false);
            builder.Property(x => x.OpenDate).HasColumnType("datetime2");
        }
    }
}
