using FluentValidation;
using VideoVault.Application.Common.Identities.Commands.CreateIdentity;

namespace VideoVault.Application.Common.Identities.Commands.AuthenticateIdentity
{
    public class AuthenticateIdentityCommandValidator : AbstractValidator<CreateIdentityCommand>
    {
        public AuthenticateIdentityCommandValidator()
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
