using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class UpsertDataSourceCommand : IRequest<DataSourceDto>
    {
        public DataSourceDto DataSource { get; set; }
    }

    public class UpsertDataSourceCommandHandler : IRequestHandler<UpsertDataSourceCommand, DataSourceDto>
    {
        private readonly IDataSourceService _dataSourceService;

        public UpsertDataSourceCommandHandler(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public async Task<DataSourceDto> Handle(UpsertDataSourceCommand request, CancellationToken cancellationToken)
        {
            return await _dataSourceService.UpsertAsync(request.DataSource);
        }
    }
}