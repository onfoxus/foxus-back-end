using Foxus.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foxus.Infrastructure.Data
{
    public class FoxusDbContext : DbContext
    {
        public FoxusDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;

            this.TarefasPrimarias.Include(tarefaPrimaria => tarefaPrimaria.TarefasSecundarias);
            this.Usuarios.Include(usuario => usuario.Execucoes);
        }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<TarefaPrimaria> TarefasPrimarias { get; set; }
        DbSet<TarefaSecundaria> TarefasSecundarias { get; set; }
        DbSet<Execucao> Execucoes { get; set; }
        DbSet<PomodoroTimer> PomodoroTimers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoxusDbContext).Assembly);
        }
    }
}
