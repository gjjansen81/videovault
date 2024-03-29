﻿using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class DeleteTemplateCommandValidator : AbstractValidator<DeleteTemplateCommand>
    {
        public DeleteTemplateCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
