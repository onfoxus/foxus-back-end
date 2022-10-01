using Foxus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foxus.Infrastructure.Data.DataMappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tbUsuario");

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Login)
                .HasColumnName("LOGIN")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Senha)
                .HasColumnName("SENHA")
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(n => n.Execucoes)
            .WithOne(n => n.Usuario)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
