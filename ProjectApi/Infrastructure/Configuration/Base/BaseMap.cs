using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Base;

namespace Infrastructure.Configuration.Base
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : EntityBase<T>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(e => e.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        }
    }
}
