using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoVault.Application.Common.Identities.Commands.AuthenticateIdentity;
using VideoVault.Application.Common.Identities.Commands.CreateIdentity;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;

namespace VideoVault.WebApi.Controllers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        private IIdentityService _identityService;

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
        public async Task<ActionResult<OutputResult<string>>> Authenticate(AuthenticateIdentityCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
