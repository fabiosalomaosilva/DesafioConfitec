using DesafioConfitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioConfitec.Infra.Data.Validations
{
    internal class UsuarioValidationConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().UseIdentityColumn();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Sobrenome).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.DataNascimento).HasColumnType("Date").IsRequired();
            builder.Property(p => p.Escolaridade).IsRequired();
        }
    }
}