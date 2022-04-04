using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetMappingNodesCommand : IRequest<List<MappingNodeDto>>
    {
    }

    public class GetMappingNodesCommandHandler : IRequestHandler<GetMappingNodesCommand, List<MappingNodeDto>>
    {
        private readonly IDataSourceService _DataSourceService;

        public GetMappingNodesCommandHandler(IDataSourceService DataSourceService)
        {
            _DataSourceService = DataSourceService;
        }

        public async Task<List<MappingNodeDto>> Handle(GetMappingNodesCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_DataSourceService.GetMappingNodes());
        }
    }
}
