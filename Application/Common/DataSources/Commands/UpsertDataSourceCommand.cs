using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Customers.Commands;
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
        private readonly IDataSourceService _DataSourceService;

        public UpsertDataSourceCommandHandler(IDataSourceService DataSourceService)
        {
            _DataSourceService = DataSourceService;
        }

        public async Task<DataSourceDto> Handle(UpsertDataSourceCommand request, CancellationToken cancellationToken)
        {
            return await _DataSourceService.UpsertAsync(request.DataSource);
        }
    }
}