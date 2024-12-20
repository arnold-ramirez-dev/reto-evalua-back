using API.Entities;
using API.Infrastructure.Configs.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Configs
{
    public class ClienteConfiguration : EntityConfiguration<ClienteEntity>
    {
        public ClienteConfiguration(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<ClienteEntity>();

            entityBuilder.ToTable("CLIENTE", "RETO");

            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(e => e.Nombre)
                .HasColumnName("NOMBRE")
                .HasColumnType("varchar(30)")
                .IsRequired();

            entityBuilder.Property(e => e.ApPaterno)
                .HasColumnName("AP_PATERNO")
                .HasColumnType("varchar(20)")
                .IsRequired();

            entityBuilder.Property(e => e.ApMaterno)
                .HasColumnName("AP_MATERNO")
                .HasColumnType("varchar(20)")
                .IsRequired();

            entityBuilder.Property(e => e.CodigoPais)
                .HasColumnName("CODIGO_PAIS")
                .HasColumnType("varchar(2)")
                .IsRequired();

            entityBuilder.Property(e => e.NumeroTelefono)
                .HasColumnName("NUMERO_TELEFONO")
                .HasColumnType("varchar(30)")
                .IsRequired();

            entityBuilder.HasOne(e => e.Pais)
                .WithMany(p => p.Clientes)
                .HasForeignKey(e => e.CodigoPais);

            Configure(entityBuilder);
        }
    }
}
