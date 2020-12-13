using FluentValidation;

namespace VideoVault.Application.Common.Users.Authentication
{
    public class AuthenticateUserCommandValidator : AbstractValidator<UpsertUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(v => v.User.Name)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(v => v.User.Email)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(v => v.User.UserName)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(v => v.User.Password)
                .MaximumLength(256)
                .NotEmpty();
        }
    }
}
