using FluentValidation;
using VideoVault.Application.Common.Identities.Commands.CreateIdentity;

namespace VideoVault.Application.Common.Customers.Commands.Get
{
    public class GetCustomerCommandValidator : AbstractValidator<GetCustomerCommand>
    {
        public GetCustomerCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
