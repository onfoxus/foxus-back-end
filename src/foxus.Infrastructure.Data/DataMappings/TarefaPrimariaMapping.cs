using Foxus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foxus.Infrastructure.Data.DataMappings
{
    internal class TarefaPrimariaMapping : IEntityTypeConfiguration<TarefaPrimaria>
    {
        public void Configure(EntityTypeBuilder<TarefaPrimaria> builder)
        {
            builder.ToTable("tbTarefaPrimaria");

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Titulo)
                .HasColumnName("TITULO")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Finalizada)
                .HasColumnName("FINALIZADA")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.Prioridade)
                .HasColumnName("PRIORIDADE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .HasColumnType("datetime");

            builder.Property(p => p.Duracao)
                .HasColumnName("DURACAO")
                .HasColumnType("time");

            builder.HasMany(n => n.TarefasSecundarias)
            .WithOne(n => n.TarefaPrimaria)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}