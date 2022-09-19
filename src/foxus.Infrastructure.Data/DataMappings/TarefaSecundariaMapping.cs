using Foxus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foxus.Infrastructure.Data.DataMappings
{
    internal class TarefaSecundariaMapping : IEntityTypeConfiguration<TarefaSecundaria>
    {
        public void Configure(EntityTypeBuilder<TarefaSecundaria> builder)
        {
            builder.ToTable("TAREFASECUNDARIA");

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
        }
    }
}
