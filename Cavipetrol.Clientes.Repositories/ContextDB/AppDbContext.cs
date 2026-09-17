using Cavipetrol.Clientes.Repositories.Clientes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cavipetrol.Clientes.Repositories.ContextDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ClienteEntity> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEntity>().ToTable("Clientes");

            modelBuilder.Entity<ClienteEntity>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(c => c.ClienteID);
            });
        }
    }
}
