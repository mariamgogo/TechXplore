using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileBank.Domain.Entities;

namespace MobileBank.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TransactionDate).HasColumnType("datetime2");
            builder.Property(x => x.Currency).IsRequired();
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            builder.Property(x=>x.DebitAccountId).IsRequired();
            builder.Property(x => x.CreditAccountId).IsRequired();

            builder.HasOne(x=>x.CreditAccount).WithMany(a=>a.CreditTransactions).HasForeignKey(x=>x.CreditAccountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.DebitAccount).WithMany(a=>a.DebitTransactions).HasForeignKey(x=>x.DebitAccountId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
