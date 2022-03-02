using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Identities.Commands.CreateIdentity
{
    public class CreateIdentityCommand : IRequest<OutputResult<string>>
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }

    public class CreateIdentityCommandHandler : IRequestHandler<CreateIdentityCommand, OutputResult<string>>
    {
        private readonly IUserService _userService;

        public CreateIdentityCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<OutputResult<string>> Handle(CreateIdentityCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult<OutputResult<string>>(null);
            //return await _userService.UpsertUserAsync(request.UserName, request.Password);
        }
    }
}
