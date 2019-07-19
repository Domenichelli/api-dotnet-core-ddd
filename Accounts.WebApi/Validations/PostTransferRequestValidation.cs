using Account.Domain.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.WebApi.Validations
{
    public class PostTransferRequestValidation : AbstractValidator<PostTransferAccountRequest>
    {
        public PostTransferRequestValidation()
        {
            RuleFor(r => r.AccountIDfrom)
                .NotEmpty()
                .WithMessage("AccountID de origem é obrigatório.");

            RuleFor(r => r.AccountIDto)
                .NotEmpty()
                .WithMessage("AccountID de destino é obrigatório.");

            RuleFor(r => r.value)
                .NotEmpty()
                .WithMessage("AccountID de destino é obrigatório.");

        }
    }
}
