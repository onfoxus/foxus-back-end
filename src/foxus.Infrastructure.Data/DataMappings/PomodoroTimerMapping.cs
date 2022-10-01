using Foxus.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foxus.Infrastructure.Data.DataMappings
{
    internal class PomodoroTimerMapping : IEntityTypeConfiguration<PomodoroTimer>
    {
        public void Configure(EntityTypeBuilder<PomodoroTimer> builder)
        {
            builder.ToTable("tbPomodoroTimer");

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(n => n.TempoFoco)
               .HasColumnName("TEMPOFOCO")
               .HasColumnType("time")
               .IsRequired();

            builder.Property(n => n.TempoDescanso)
                .HasColumnName("TEMPODESCANSO")
                .HasColumnType("time")
                .IsRequired();
        }
    }
}
