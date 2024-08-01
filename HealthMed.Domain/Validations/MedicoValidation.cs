using FluentValidation.Validators;
using FluentValidation;
using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Validations
{
    public class MedicoValidaton : AbstractValidator<Medico>
    {
        public MedicoValidaton()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(m => m.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.");

            RuleFor(m => m.CRM)
                .NotEmpty().WithMessage("O CRM é obrigatório.")
                .Length(5, 20).WithMessage("O CRM deve ter entre 5 e 20 caracteres.");

            RuleFor(e => e.Email)
               .NotEmpty().WithMessage("O endereço de email é obrigatório.")
               .EmailAddress().WithMessage("O endereço de email é inválido.");

            RuleFor(p => p.Password)
                .NotNull().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
        }
    }
}
