﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;

namespace VideoVault.Application.Common.Customers.Commands
{
    public class DeleteTemplateCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteTemplateCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            await _customerService.DeleteAsync(request.Id);
            return true;
        }
    }
}
