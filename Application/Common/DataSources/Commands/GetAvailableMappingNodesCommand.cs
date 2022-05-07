using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class GetAvailableMappingNodesCommand : IRequest<List<MappingNodeDto>>
    {
    }

    public class GetAvailableMappingNodesCommandHandler : IRequestHandler<GetAvailableMappingNodesCommand, List<MappingNodeDto>>
    {
        private readonly IDataSourceService _dataSourceService;

        public GetAvailableMappingNodesCommandHandler(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public async Task<List<MappingNodeDto>> Handle(GetAvailableMappingNodesCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_dataSourceService.GetAvailableMappingNodes());
        }
    }
}
