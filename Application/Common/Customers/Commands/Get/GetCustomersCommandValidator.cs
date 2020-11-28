using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands.Get
{
    public class GetCustomersCommandValidator : AbstractValidator<GetCustomersCommand>
    {
        public GetCustomersCommandValidator()
        {
        }
    }
}
