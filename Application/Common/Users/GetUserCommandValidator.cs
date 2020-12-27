using FluentValidation;

namespace VideoVault.Application.Common.Users
{
    public class GetUserCommandValidator : AbstractValidator<GetUserCommand>
    {
        public GetUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty();
        }
    }
}
