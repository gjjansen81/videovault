using FluentValidation;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetAvailableMappingNodesCommandValidator : AbstractValidator<GetAvailableMappingNodesCommand>
    {
        public GetAvailableMappingNodesCommandValidator()
        {
        }
    }
}
