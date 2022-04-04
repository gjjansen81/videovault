using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetDataSourcesCommand : IRequest<List<DataSourceDto>>
    {
    }

    public class GetDataSourcesCommandHandler : IRequestHandler<GetDataSourcesCommand, List<DataSourceDto>>
    {
        private readonly IDataSourceService _dataSourceService;

        public GetDataSourcesCommandHandler(IDataSourceService DataSourceService)
        {
            _dataSourceService = DataSourceService;
        }   

        public async Task<List<DataSourceDto>> Handle(GetDataSourcesCommand request, CancellationToken cancellationToken)
        {
            return await _dataSourceService.GetAsync();
        }
    }
}
