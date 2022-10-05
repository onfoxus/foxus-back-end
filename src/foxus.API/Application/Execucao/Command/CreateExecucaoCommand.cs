using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Foxus.API.Application.Execucao.Validation;
using Foxus.Domain;
using System.Threading;

namespace Foxus.API.Application.Execucao.Command
{
    public class CreateExecucaoCommand : IRequest<bool>
    {
        public List<TarefaPrimaria> TarefasPrimarias { get; set; }
        public TimeSpan Duracao { get; set; }
        public Domain.PomodoroTimer PomodoroTimer { get; set; }
        public Domain.Usuario Usuario { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreateExecucaoCommand(List<TarefaPrimaria> tarefasPrimarias, TimeSpan duracao, Domain.PomodoroTimer pomodoroTimer, Domain.Usuario usuario)
        {
            TarefasPrimarias = new List<TarefaPrimaria>();
            foreach (TarefaPrimaria tarefaPrimaria in tarefasPrimarias)
            {
                TarefasPrimarias.Add(tarefaPrimaria);
            }

            Duracao = duracao;
            PomodoroTimer = pomodoroTimer;
            Usuario = usuario;

            var validator = new CreateExecucaoCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
