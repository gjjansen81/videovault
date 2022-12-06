using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;

namespace VideoVault.Application.Common.DataSources.Commands
{
    public class DeleteDataSourceCommand : IRequest<bool>
    {
        public Guid Guid { get; set; }
    }

    public class DeleteDataSourceCommandHandler : IRequestHandler<DeleteDataSourceCommand, bool>
    {
        private readonly IDataSourceService _DataSourceService;

        public DeleteDataSourceCommandHandler(IDataSourceService DataSourceService)
        {
            _DataSourceService = DataSourceService;
        }

        public async Task<bool> Handle(DeleteDataSourceCommand request, CancellationToken cancellationToken)
        {
            await _DataSourceService.DeleteAsync(request.Guid);
            return true;
        }
    }
}
