using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoVault.Application.Common.Identities.Commands.CreateIdentity;
using VideoVault.Application.Common.Models;

namespace VideoVault.WebApi.Controllers
{
    //[Authorize]
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<OutputResult<string>>> Create(CreateIdentityCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, object command)
        {
           // if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Get(int id)
        {
           // if (id != command.Id)
            {
                return BadRequest();
            }

            //await Mediator.Send(new GetCustomerCommand { Id = id });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           // await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
