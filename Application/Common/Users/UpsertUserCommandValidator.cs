using FluentValidation;

namespace VideoVault.Application.Common.Users
{
    public class UpsertUserCommandValidator : AbstractValidator<UpsertUserCommand>
    {
        public UpsertUserCommandValidator()
        {
            RuleFor(v => v.User)
                .NotEmpty();
            RuleFor(v => v.User.LastName)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(v => v.User.Email)
                .MaximumLength(256)
                .EmailAddress()
                .NotEmpty();
            RuleFor(v => v.User.UserName)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(v => v.User.Password)
                .MaximumLength(256)
                .MinimumLength(8)
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                .Must((v, password) => password.Equals(v.User.PasswordConfirm) )
                .NotEmpty();
        }
    }
}
