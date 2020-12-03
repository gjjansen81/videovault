using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Domain.Entities;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
    }

    public class GetCustomerCommandHandler : IRequestHandler<GetCustomerCommand, Customer>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Customer> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _customerService.GetCustomerAsync(request.Id));
        }
    }
}
