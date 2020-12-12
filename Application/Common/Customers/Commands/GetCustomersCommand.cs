using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetCustomersCommand : IRequest<List<CustomerDto>>
    {
    }

    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersCommand, List<CustomerDto>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomersAsync();
        }
    }
}
