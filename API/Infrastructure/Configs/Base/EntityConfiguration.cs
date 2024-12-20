using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Configs.Base
{
    public abstract class EntityConfiguration<T> : IEntityConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            if (typeof(T).GetProperty("ID") != null)
            {
                builder.Property("ID")
                       .HasColumnType("int")
                       .HasColumnName("ID")
                       .IsRequired()
                       .UseIdentityColumn();
            }

            if (typeof(T).GetProperty("ESTADO") != null)
            {
                builder.Property("ESTADO")
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .IsRequired();
            }

            if (typeof(T).GetProperty("FechaCreacion") != null)
            {
                builder.Property("FechaCreacion")
                       .HasColumnType("datetime")
                       .HasColumnName("FECHA_CREACION")
                       .HasDefaultValueSql("GETDATE()")
                       .IsRequired();
            }
        }
    }
}
