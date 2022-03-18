using FluentValidation;

namespace VideoVault.Application.Common.Templates.Commands
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
