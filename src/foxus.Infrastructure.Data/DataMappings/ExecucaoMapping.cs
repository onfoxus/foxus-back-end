using Foxus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foxus.Infrastructure.Data.DataMappings
{
    internal class ExecucaoMapping : IEntityTypeConfiguration<Execucao>
    {
        public void Configure(EntityTypeBuilder<Execucao> builder)
        {
            builder.ToTable("EXECUCAO");

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.HasMany(n => n.TarefasPrimarias);

            builder.Property(n => n.Duracao)
                .HasColumnName("DURACAO")
                .HasColumnType("time")
                .IsRequired();

            builder.HasOne(n => n.Usuario)
                .WithMany(p => p.Execucoes)
                .HasForeignKey(k => k.UsuarioId);

            builder.HasOne(n => n.PomodoroTimer);
        }
    }
}
