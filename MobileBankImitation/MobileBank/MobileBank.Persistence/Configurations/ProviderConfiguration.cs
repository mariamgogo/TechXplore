using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBank.Domain.Entities;

namespace MobileBank.Persistence.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x=>x.LogoLink).HasMaxLength(200);
                
        }

    }
}
