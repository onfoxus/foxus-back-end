using System.Collections.Generic;

namespace Foxus.Domain
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Nome { get; set; }
        public virtual List<Execucao> Execucoes { get; set; }
    }
}
