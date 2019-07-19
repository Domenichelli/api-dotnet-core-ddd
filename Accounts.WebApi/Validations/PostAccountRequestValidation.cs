using Account.Application.Helpers;
using Account.Domain.Contracts;
using Account.Interface.Business;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.WebApi.Validations
{
    public class PostAccountRequestValidation : AbstractValidator<PostClientAccountRequest>
    {
        public PostAccountRequestValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(r => r.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório.");

            RuleFor(r => r.CPF)
                .Must(Helpers.IsCpf)
                .WithMessage("CPF não é válido.");

            RuleFor(r => r.AccountNumber)
                .Must(Helpers.IsAccount)
                .WithMessage("Conta invalida");

            RuleFor(r => r.AgencyNumber)
                .Must(Helpers.IsAgency)
                .WithMessage("Agencia invalida");
        }
    }
}
