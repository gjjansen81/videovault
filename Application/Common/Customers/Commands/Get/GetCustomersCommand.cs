using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;

namespace VideoVault.Application.Common.Customers.Commands.Get
{
    public class GetCustomersCommand : IRequest<List<Customer>>
    {
    }

    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersCommand, List<Customer>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<List<Customer>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_customerService.GetCustomers());
        }
    }
}
