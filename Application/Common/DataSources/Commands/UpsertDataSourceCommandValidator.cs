using FluentValidation;
using VideoVault.Application.Common.Customers.Commands;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class UpsertDataSourceCommandValidator : AbstractValidator<UpsertDataSourceCommand>
    {
        public UpsertDataSourceCommandValidator()
        {
            RuleFor(v => v.DataSource)
                .NotEmpty();
        }
    }
}
