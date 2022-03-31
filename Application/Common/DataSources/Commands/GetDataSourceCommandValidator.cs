using System;
using FluentValidation;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetDataSourceCommandValidator : AbstractValidator<GetDataSourceCommand>
    {
        public GetDataSourceCommandValidator()
        {
            RuleFor(v => v.Guid)
                .NotEqual(Guid.Empty)
                .NotEmpty();
        }
    }
}
