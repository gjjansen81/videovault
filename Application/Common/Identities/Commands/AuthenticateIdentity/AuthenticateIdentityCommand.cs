using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Identities.Commands.AuthenticateIdentity
{
    public class AuthenticateIdentityCommand : IRequest<OutputResult<AuthenticationDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateIdentityCommandHandler : IRequestHandler<AuthenticateIdentityCommand, OutputResult<AuthenticationDto>>
    {
        private readonly IIdentityService _identityService;

        public AuthenticateIdentityCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<OutputResult<AuthenticationDto>> Handle(AuthenticateIdentityCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.AuthenticateAsync(request.UserName, request.Password);
        }
    }
}