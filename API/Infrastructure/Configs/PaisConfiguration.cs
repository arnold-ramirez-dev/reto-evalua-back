using API.Entities;
using API.Infrastructure.Configs.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Configs
{
    public class PaisConfiguration : EntityConfiguration<PaisEntity>
    {
        public PaisConfiguration(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<PaisEntity>();

            entityBuilder.ToTable("PAIS", "RETO");

            entityBuilder.HasKey(e => e.Codigo);

            entityBuilder.Property(e => e.Codigo)
                .HasColumnName("CODIGO")
                .HasColumnType("varchar(2)")
                .IsRequired();

            entityBuilder.Property(e => e.Nombre)
                .HasColumnName("NOMBRE")
                .HasColumnType("varchar(100)")
                .IsRequired();

            entityBuilder.HasMany(e => e.Clientes)
                .WithOne(c => c.Pais)
                .HasForeignKey(c => c.CodigoPais);
        }
    }
}
