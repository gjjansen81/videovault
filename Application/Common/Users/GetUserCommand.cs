using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Users
{
    public class GetUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
    }

    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, UserDto>
    {
        private readonly IUserService _userService;

        public GetUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _userService.GetUserAsync(request.Id.ToString()));
        }
    }
}
