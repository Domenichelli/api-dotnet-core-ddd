using Account.Domain.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Accounts.WebApi.Validations
{
    public static class ExecuteValidations
    {
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<PostClientAccountRequest>, PostAccountRequestValidation>();
            return services;
        }
    }
}
