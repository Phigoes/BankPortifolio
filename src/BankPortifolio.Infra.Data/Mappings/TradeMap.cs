using BankPortifolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankPortifolio.Infra.Data.Mappings
{
    public class TradeMap : MapBase<Trade>
    {
        public override void Configure(EntityTypeBuilder<Trade> builder)
        {
            base.Configure(builder);
            builder.ToTable("Trade");
            builder.Property(c => c.Value).IsRequired().HasColumnName("Value");
            builder.Property(c => c.ClientSector).IsRequired().HasColumnName("ClientSector").HasMaxLength(20);
            builder.Property(c => c.Category).IsRequired().HasColumnName("Category").HasMaxLength(20);
        }
    }
}
