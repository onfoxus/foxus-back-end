using Foxus.Domain;
using Microsoft.EntityFrameworkCore;

namespace Foxus.Infrastructure.Data
{
    public class FoxusDbContext : DbContext
    {
        public FoxusDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<TarefaPrimaria> TarefasPrimarias { get; set; }
        DbSet<TarefaSecundaria> TarefasSecundarias { get; set; }
        DbSet<Execucao> Execucoes { get; set; }
        DbSet<Execucao> PomodoroTimers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoxusDbContext).Assembly);
        }
    }
}
