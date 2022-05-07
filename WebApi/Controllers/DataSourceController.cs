using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;
using VideoVault.Application.Common.DataSources.Commands;

namespace VideoVault.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DataSourceController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<DataSourceDto>> Create(UpsertDataSourceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{guid}")]
        public async Task<ActionResult<DataSourceDto>> Update(Guid guid, UpsertDataSourceCommand command)
        {
            if (guid != command.DataSource.Guid)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<DataSourceDto>>> Get()
        {
            return await Mediator.Send(new GetDataSourcesCommand { });
        }

        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<DataSourceDto>> GetById(Guid guid)
        {
            return await Mediator.Send(new GetDataSourceCommand { Guid = guid });
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(Guid guid)
        {
            await Mediator.Send(new DeleteDataSourceCommand { Guid = guid });

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<MappingNodeDto>>> GetAvailableMappingNodes()
        {
            return await Mediator.Send(new GetAvailableMappingNodesCommand { });
        }
    }
}
