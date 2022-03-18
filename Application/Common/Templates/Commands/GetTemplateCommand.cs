﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class GetTemplateCommand : IRequest<TemplateDto>
    {
        public int Id { get; set; }
    }

    public class GetTemplateCommandHandler : IRequestHandler<GetTemplateCommand, TemplateDto>
    {
        private readonly ITemplateService _templateService;

        public GetTemplateCommandHandler(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public async Task<TemplateDto> Handle(GetTemplateCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _templateService.GetSingleAsync(request.Id));
        }
    }
}
