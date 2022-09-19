using System;
using System.Collections.Generic;

namespace Foxus.Domain
{
    public class TarefaPrimaria : Tarefa
    {
        public List<TarefaSecundaria> TarefasSecundarias { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataCadastro { get; set; }
        public TimeSpan Duracao { get; set; }
    }
}
