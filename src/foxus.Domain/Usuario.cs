using System.Collections.Generic;

namespace Foxus.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public List<Execucao> Execucoes { get; set; }
    }
}
