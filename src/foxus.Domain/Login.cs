using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxus.Domain
{
    public class Login
    {
        public virtual string LoginUsuario { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Token { get; set; }
    }
}
