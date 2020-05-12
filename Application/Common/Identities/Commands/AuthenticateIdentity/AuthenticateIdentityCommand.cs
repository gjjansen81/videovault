using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Identities.Commands.AuthenticateIdentity
{
    public class AuthenticateIdentityCommand : IRequest<OutputResult<string>>
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }

    public class AuthenticateIdentityCommandHandler : IRequestHandler<AuthenticateIdentityCommand, OutputResult<string>>
    {
        private readonly IIdentityService _identityService;

        public AuthenticateIdentityCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<OutputResult<string>> Handle(AuthenticateIdentityCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.AuthenticateAsync(request.UserName, request.Password);
        }
    }
}