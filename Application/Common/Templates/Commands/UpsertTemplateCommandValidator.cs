using FluentValidation;
using VideoVault.Application.Common.Customers.Commands;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class UpsertTemplateCommandValidator : AbstractValidator<UpsertTemplateCommand>
    {
        public UpsertTemplateCommandValidator()
        {
            RuleFor(v => v.Template)
                .NotEmpty();
        }
    }
}
