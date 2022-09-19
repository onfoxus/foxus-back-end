using System;
using System.Collections.Generic;

namespace Foxus.Domain
{
    public class Execucao
    {
        public int Id { get; set; }
        public List<TarefaPrimaria> TarefasPrimarias { get; set; }
        public TimeSpan Duracao { get; set; }
        public PomodoroTimer PomodoroTimer { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}
