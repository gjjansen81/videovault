using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class UpsertCustomerCommand : IRequest<CustomerDto>
    {
        public CustomerDto Customer { get; set; }
    }

    public class UpsertCustomerCommandHandler : IRequestHandler<UpsertCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public UpsertCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(UpsertCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _customerService.UpsertAsync(request.Customer);
        }
    }
}