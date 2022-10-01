using System;
using System.Collections.Generic;

namespace Foxus.Domain
{
    public class Execucao
    {
        public virtual int Id { get; set; }
        public virtual List<TarefaPrimaria> TarefasPrimarias { get; set; }
        public virtual TimeSpan Duracao { get; set; }
        public virtual PomodoroTimer PomodoroTimer { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual int UsuarioId { get; set; }
    }
}
