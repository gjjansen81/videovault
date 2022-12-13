using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;
using VideoVault.Application.Common.Templates.Commands;

namespace VideoVault.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TemplateController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<SpreadSheetTemplateDto>> Create(UpsertTemplateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SpreadSheetTemplateDto>> Update(int id, UpsertTemplateCommand command)
        {
            if (id != command.SpreadSheetTemplate.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<SpreadSheetTemplateDto>>> Get()
        {
            return await Mediator.Send(new GetTemplatesCommand { });
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<SpreadSheetTemplateDto>> GetById(int id)
        {
            return await Mediator.Send(new GetTemplateCommand { Id = id });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SpreadSheetTemplateDto>> AddSheet(AddSheetTemplateCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
