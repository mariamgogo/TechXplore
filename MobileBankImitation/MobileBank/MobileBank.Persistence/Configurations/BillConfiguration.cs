using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBank.Domain.Entities;

namespace MobileBank.Persistence.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        void IEntityTypeConfiguration<Bill>.Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");
            builder.HasKey(x=>x.Id);;
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Provider).WithMany(x => x.Bills).HasForeignKey(x => x.ProviderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.Bills).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
