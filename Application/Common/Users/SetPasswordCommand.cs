using System;
using MediatR;  
using System.Threading;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Users
{
    public class SetPasswordCommand : IRequest<Result>
    {
        public PasswordDto PasswordDto { get; set; }
    }

    public class SetPasswordCommandHandler : IRequestHandler<SetPasswordCommand, Result>
    {
        private readonly IUserService _userService;

        public SetPasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userService.SetPasswordAsync(request.PasswordDto.Id.ToString(), request.PasswordDto.Password);
        }
    }
}