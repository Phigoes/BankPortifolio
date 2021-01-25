using BankPortifolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankPortifolio.Infra.Data.Mappings
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired().HasColumnName("Id");
        }
    }
}
