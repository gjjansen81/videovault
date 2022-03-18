using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class GetTemplatesCommand : IRequest<List<TemplateDto>>
    {
    }

    public class GetTemplatesCommandHandler : IRequestHandler<GetTemplatesCommand, List<TemplateDto>>
    {
        private readonly ITemplateService _templateService;

        public GetTemplatesCommandHandler(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public async Task<List<TemplateDto>> Handle(GetTemplatesCommand request, CancellationToken cancellationToken)
        {
            return await _templateService.GetAsync();
        }
    }
}
