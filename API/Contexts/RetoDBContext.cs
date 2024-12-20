using API.Entities;
using API.Infrastructure.Configs;
using API.Support.DTO.Clients;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
    public class RetoDBContext : DbContext
    {
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<PaisEntity> Paises { get; set; }
        public DbSet<DtoGetListClienteSP> DtoGetListClienteSP { get; set; }

        public RetoDBContext(DbContextOptions<RetoDBContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(3600);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteConfiguration(builder));
            builder.ApplyConfiguration(new PaisConfiguration(builder));
        }
    }
}
