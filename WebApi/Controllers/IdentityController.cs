using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoVault.Application.Common.Identities.Commands.CreateIdentity;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Application.Common.Users.Authentication;

namespace VideoVault.WebApi.Controllers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        private IUserService _userService;

        public IdentityController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<OutputResult<string>>> Create(CreateIdentityCommand command)
        {
            return await Mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult<OutputResult<AuthenticationDto>>> Authenticate(string userName, string password)
        {
            return await Mediator.Send(new AuthenticateUserCommand { UserName = userName, Password = password});
        }
    }
}
