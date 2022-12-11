using FluentValidation;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class AddSheetTemplateCommandValidator : AbstractValidator<AddSheetTemplateCommand>
    {
        public AddSheetTemplateCommandValidator()
        {
            RuleFor(v => v.SpreadSheetTemplate)
                .NotEmpty();
            RuleFor(v => v.Name)
                .NotEmpty();
        }
    }
}
