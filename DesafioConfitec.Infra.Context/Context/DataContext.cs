using DesafioConfitec.Domain.Entities;
using DesafioConfitec.Infra.Data.Validations;
using Microsoft.EntityFrameworkCore;

namespace DesafioConfitec.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioValidationConfig());
        }
    }
}