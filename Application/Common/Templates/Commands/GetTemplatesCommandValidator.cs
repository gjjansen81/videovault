using FluentValidation;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class GetTemplatesCommandValidator : AbstractValidator<GetTemplatesCommand>
    {
        public GetTemplatesCommandValidator()
        {
        }
    }
}
