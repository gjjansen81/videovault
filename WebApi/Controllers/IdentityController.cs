using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoVault.Application.Common.Interfaces;

namespace VideoVault.WebApi.Controllers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        private IIdentityService _identityService;

        [HttpPost]
        public async Task<ActionResult<int>> Authenticate(int command)
        {
            return BadRequest();
            //return await Mediator.Send(command);
        }
    }
}
