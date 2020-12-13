using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Users.Authentication
{
    public class AuthenticateUserCommand : IRequest<OutputResult<AuthenticationDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, OutputResult<AuthenticationDto>>
    {
        private readonly IUserService _userService;

        public AuthenticateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<OutputResult<AuthenticationDto>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AuthenticateAsync(request.UserName, request.Password);
        }
    }
}