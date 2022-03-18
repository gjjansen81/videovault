using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Customers.Commands;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class UpsertTemplateCommand : IRequest<TemplateDto>
    {
        public TemplateDto Template { get; set; }
    }

    public class UpsertTemplateCommandHandler : IRequestHandler<UpsertTemplateCommand, TemplateDto>
    {
        private readonly ITemplateService _templateService;

        public UpsertTemplateCommandHandler(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public async Task<TemplateDto> Handle(UpsertTemplateCommand request, CancellationToken cancellationToken)
        {
            return await _templateService.UpsertAsync(request.Template);
        }
    }
}