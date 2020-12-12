using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class GetCustomerCommand : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }

    public class GetCustomerCommandHandler : IRequestHandler<GetCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _customerService.GetCustomerAsync(request.Id));
        }
    }
}
