using DesafioConfitec.Services.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioConfitec.Services.Validation
{
    public class UserValidator : AbstractValidator<UsuarioDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O campo Nome é obrigatório.");
            RuleFor(x => x.Sobrenome).NotNull().WithMessage("O campo Sobrenome é obrigatório.");
            RuleFor(x => x.Email).NotNull().WithMessage("O campo de E-mail é obrigatório.").EmailAddress().WithMessage("O E-mail informado é inválido.");
            RuleFor(x => x.DataNascimento).NotNull().ExclusiveBetween(DateTime.MinValue, DateTime.Now).WithMessage("A data de nascimento não pode ser superior ao dia atual.");
            RuleFor(x => x.Escolaridade).NotNull().WithMessage("A Esclaridade é obrigatória.");
        }
    }
}
