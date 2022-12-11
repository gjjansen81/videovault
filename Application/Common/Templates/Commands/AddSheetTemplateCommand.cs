using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class AddSheetTemplateCommand : IRequest<SpreadSheetTemplateDto>
    {
        public SpreadSheetTemplateDto SpreadSheetTemplate { get; set; }
        public string Name { get; set; }
    }

    public class AddSheetTemplateCommandHandler : IRequestHandler<AddSheetTemplateCommand, SpreadSheetTemplateDto>
    {
        private readonly ITemplateService _templateService;

        public AddSheetTemplateCommandHandler(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public async Task<SpreadSheetTemplateDto> Handle(AddSheetTemplateCommand request, CancellationToken cancellationToken)
        {
            return await _templateService.AddSheetAsync(request.SpreadSheetTemplate, request.Name);
        }
    }
}