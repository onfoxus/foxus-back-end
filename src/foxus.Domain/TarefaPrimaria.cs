using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Foxus.Domain
{
    public class TarefaPrimaria : Tarefa
    {
        public virtual string Descricao { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual int Prioridade { get; set; }
        public virtual TimeSpan Duracao { get; set; }
        public virtual List<TarefaSecundaria> TarefasSecundarias { get; set; }
    }
}
