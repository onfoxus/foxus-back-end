using Foxus.Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace Foxus.API.Application.TaskPrimaria.Command
{
    public class UpdateTarefaPrimariaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Finalizada { get; set; }
        public List<TarefaSecundaria> TarefasSecundarias { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataCadastro { get; set; }
        public TimeSpan Duracao { get; set; }
        public List<Domain.Execucao> Execucoes { get; set; }

    }
}
