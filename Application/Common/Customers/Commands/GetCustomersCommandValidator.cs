using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetCustomersCommandValidator : AbstractValidator<GetCustomersCommand>
    {
        public GetCustomersCommandValidator()
        {
        }
    }
}
