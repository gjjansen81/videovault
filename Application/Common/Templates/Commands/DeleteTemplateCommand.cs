using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;

namespace VideoVault.Application.Common.Templates.Commands
{
    public class DeleteTemplateCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteTemplateCommand, bool>
    {
        private readonly ITemplateService _templateService;

        public DeleteCustomerCommandHandler(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public async Task<bool> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            await _templateService.DeleteAsync(request.Id);
            return true;
        }
    }
}
