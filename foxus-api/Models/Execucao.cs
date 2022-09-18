using System;
using System.Collections.Generic;

namespace foxus_api.Models
{
    public class Execucao
    {
        public int Id { get; set; }
        public List<TarefaPrimaria> TarefasPrimarias { get; set; }
        public TimeSpan Duracao { get; set; }
        public PomodoroTimer PomodoroTimer { get; set; }
    }
}
