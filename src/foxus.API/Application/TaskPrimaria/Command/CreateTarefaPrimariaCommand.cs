using FluentValidation.Results;
using Foxus.API.Application.TaskPrimaria.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using Foxus.Domain;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Foxus.API.Application.TaskPrimaria.Command
{

    public class CreateTarefaPrimariaCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public bool Finalizada { get; set; }
        public List<TarefaSecundaria> TarefasSecundarias { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataCadastro { get; set; }
        public TimeSpan Duracao { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreateTarefaPrimariaCommand(string titulo, bool finalizada, List<TarefaSecundaria> tarefasSecundarias, string descricao, int prioridade, DateTime dataCadastro, TimeSpan duracao)
        {
            Titulo = titulo;
            Finalizada = finalizada;
            Descricao = descricao;
            Prioridade = prioridade;
            DataCadastro = dataCadastro;
            Duracao = duracao;

            TarefasSecundarias = new List<TarefaSecundaria>();
            foreach (TarefaSecundaria tarefaSecundaria in tarefasSecundarias)
            {
                TarefasSecundarias.Add(tarefaSecundaria);
            }

            var validatorTarefaPrimaria = new CreateTarefaPrimariaCommandValidator();
            Validation = validatorTarefaPrimaria.Validate(this);
        }
    }

}