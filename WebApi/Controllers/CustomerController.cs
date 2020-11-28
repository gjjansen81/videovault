using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Customers.Commands.Get;
using VideoVault.Domain.Entities;

namespace VideoVault.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(int command)
        {
            return BadRequest();
            //return await Mediator.Send(command);
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

        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await Mediator.Send(new GetCustomersCommand { });
        }

        [HttpGet("[action]/{id}")]
        public async Task<Customer> GetById(int id)
        {
            return await Mediator.Send(new GetCustomerCommand { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           // await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
