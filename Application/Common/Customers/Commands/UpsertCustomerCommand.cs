using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Domain.Entities;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class UpsertCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }

    public class UpsertCustomerCommandHandler : IRequestHandler<UpsertCustomerCommand, Customer>
    {
        private readonly ICustomerService _customerService;

        public UpsertCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Customer> Handle(UpsertCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _customerService.UpsertCustomerAsync(request.Customer);
        }
    }
}