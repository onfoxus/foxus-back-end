using System.Text.Json.Serialization;

namespace Foxus.Domain
{
    public class TarefaSecundaria : Tarefa
    {
        public virtual TarefaPrimaria TarefaPrimaria { get; set; }
        [JsonIgnore]
        public virtual int TarefaPrimariaId { get; set; }
    }
}
