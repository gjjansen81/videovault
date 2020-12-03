using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands
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
