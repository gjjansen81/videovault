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
        private readonly IDataSourceService _dataSourceService;

        public GetMappingNodesCommandHandler(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public async Task<List<MappingNodeDto>> Handle(GetMappingNodesCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_dataSourceService.GetMappingNodes());
        }
    }
}
