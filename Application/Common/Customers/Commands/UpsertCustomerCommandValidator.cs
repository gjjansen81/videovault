using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class UpsertCustomerCommandValidator : AbstractValidator<UpsertCustomerCommand>
    {
        public UpsertCustomerCommandValidator()
        {
            RuleFor(v => v.Customer)
                .NotEmpty();
        }
    }
}
