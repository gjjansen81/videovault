using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetTemplatesCommand : IRequest<List<CustomerDto>>
    {
    }

    public class GetCustomersCommandHandler : IRequestHandler<GetTemplatesCommand, List<CustomerDto>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<List<CustomerDto>> Handle(GetTemplatesCommand request, CancellationToken cancellationToken)
        {
            return await _customerService.GetAsync();
        }
    }
}
