using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Users
{
    public class GetUsersCommand : IRequest<List<UserDto>>
    {
    }

    public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, List<UserDto>>
    {
        private readonly IUserService _userService;

        public GetUsersCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserDto>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsersAsync();
        }
    }
}
