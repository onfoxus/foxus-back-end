using Foxus.Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace Foxus.API.Application.Execucao.Command
{
    public class UpdateExecucaoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public List<TarefaPrimaria> TarefasPrimarias { get; set; }
        public TimeSpan Duracao { get; set; }
        public Domain.PomodoroTimer PomodoroTimer { get; set; }
        public Domain.Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}
