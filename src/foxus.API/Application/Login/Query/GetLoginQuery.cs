using MediatR;

namespace Foxus.API.Application.Login.Query
{
    public class GetLoginQuery : IRequest<Domain.Login>
    {
        public GetLoginQuery(string login, string senha)
        {
            LoginUsuario = login;
            Senha = senha;
        }

        public string LoginUsuario { get; set; }
        public string Senha { get; set; }
    }
}
