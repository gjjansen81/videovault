﻿using FluentValidation;
using VideoVault.Application.Common.Users.Commands;

namespace VideoVault.Application.Common.Users
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
