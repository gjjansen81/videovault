﻿using FluentValidation;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetTemplatesCommandValidator : AbstractValidator<GetTemplatesCommand>
    {
        public GetTemplatesCommandValidator()
        {
        }
    }
}
