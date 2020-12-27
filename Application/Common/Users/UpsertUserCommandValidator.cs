using FluentValidation;

namespace VideoVault.Application.Common.Users
{
    public class UpsertUserCommandValidator : AbstractValidator<UpsertUserCommand>
    {
        public UpsertUserCommandValidator()
        {
            RuleFor(v => v.User)
                .NotEmpty();
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
