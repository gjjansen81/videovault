using System;
using FluentValidation;

namespace VideoVault.Application.Common.Users
{
    public class SetPasswordCommandValidator : AbstractValidator<SetPasswordCommand>
    {
        public SetPasswordCommandValidator()
        {
            RuleFor(v => v.PasswordDto)
                .NotEmpty();
            RuleFor(v => v.PasswordDto.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);
            RuleFor(v => v.PasswordDto.Password)
                .MaximumLength(256)
                .MinimumLength(8)
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                .Must((v, password) => password.Equals(v.PasswordDto.PasswordConfirm) )
                .NotEmpty();
        }
    }
}
