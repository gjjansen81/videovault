using FluentValidation;

namespace VideoVault.Application.Common.Users.Authentication
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(v => v.UserName)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(v => v.Password)
                .MaximumLength(256)
                .NotEmpty();
        }
    }
}
