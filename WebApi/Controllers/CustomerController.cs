﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Customers.Commands;
using VideoVault.Application.Common.Models;

namespace VideoVault.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(UpsertCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(int id, UpsertCustomerCommand command)
        {
            if (id != command.Customer.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<CustomerDto>>> Get()
        {
            return await Mediator.Send(new GetCustomersCommand { });
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            return await Mediator.Send(new GetCustomerCommand { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}
