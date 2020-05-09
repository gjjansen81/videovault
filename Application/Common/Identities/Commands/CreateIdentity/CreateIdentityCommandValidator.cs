using FluentValidation;

namespace VideoVault.Application.Common.Identities.Commands.CreateIdentity
{
    public class CreateIdentityCommandValidator : AbstractValidator<CreateIdentityCommand>
    {
        public CreateIdentityCommandValidator()
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
