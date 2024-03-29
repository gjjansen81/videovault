﻿using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetTemplateCommandValidator : AbstractValidator<GetTemplateCommand>
    {
        public GetTemplateCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
