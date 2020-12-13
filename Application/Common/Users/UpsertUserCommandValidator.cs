using FluentValidation;

namespace VideoVault.Application.Common.Users
{
    public class UpsertUserCommandValidator : AbstractValidator<UpsertUserCommand>
    {
        public UpsertUserCommandValidator()
        {
            RuleFor(v => v.User)
                .NotEmpty();
        }
    }
}
