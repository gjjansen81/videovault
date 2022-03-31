using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetDataSourceCommand : IRequest<DataSourceDto>
    {
        public Guid Guid { get; set; }
    }

    public class GetDataSourceCommandHandler : IRequestHandler<GetDataSourceCommand, DataSourceDto>
    {
        private readonly IDataSourceService _DataSourceService;

        public GetDataSourceCommandHandler(IDataSourceService DataSourceService)
        {
            _DataSourceService = DataSourceService;
        }

        public async Task<DataSourceDto> Handle(GetDataSourceCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _DataSourceService.GetSingleAsync(request.Guid));
        }
    }
}
