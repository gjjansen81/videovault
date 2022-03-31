using FluentValidation;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetDataSourcesCommandValidator : AbstractValidator<GetDataSourcesCommand>
    {
        public GetDataSourcesCommandValidator()
        {
        }
    }
}
