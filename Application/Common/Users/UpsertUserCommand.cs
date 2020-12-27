using MediatR;  
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Users
{
    public class UpsertUserCommand : IRequest<OutputResult<UserDto>>
    {
        public UserDto User { get; set; }
    }

    public class UpsertUserCommandHandler : IRequestHandler<UpsertUserCommand, OutputResult<UserDto>>
    {
        private readonly IUserService _userService;

        public UpsertUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<OutputResult<UserDto>> Handle(UpsertUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUserAsync(request.User);
        }
    }
}