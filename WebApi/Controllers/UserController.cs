using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;
using VideoVault.Application.Common.Users;
using VideoVault.Application.Common.Users.Authentication;

namespace VideoVault.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult<OutputResult<AuthenticationDto>>> Authenticate(string userName, string password)
        {
            return await Mediator.Send(new AuthenticateUserCommand { UserName = userName, Password = password });
        }

        [HttpPost]
        public async Task<OutputResult<UserDto>> Create(UpsertUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UpsertUserCommand command)
        {
            if (id != command.User.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            return await Mediator.Send(new GetUsersCommand { });
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await Mediator.Send(new GetUserCommand { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}
