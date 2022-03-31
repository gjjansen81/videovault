using FluentValidation;
using System;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class DeleteDataSourceCommandValidator : AbstractValidator<DeleteDataSourceCommand>
    {
        public DeleteDataSourceCommandValidator()
        {
            RuleFor(v => v.Guid)
                .NotEqual(Guid.Empty)
                .NotEmpty();
        }
    }
}
