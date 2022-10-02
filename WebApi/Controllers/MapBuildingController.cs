﻿using Microsoft.AspNetCore.Authorization;
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
    public class MapBuildingController : ApiController
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
        /*
        [HttpGet("[action]")]
        public async Task<ActionResult<List<TemplateDto>>> Get()
        {
            //  return await Mediator.Send(new GetTemplateCommand { });
        }*/

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<SpreadSheetTemplateDto>> GetById(int id)
        {
            return await Mediator.Send(new GetTemplateCommand { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTemplateCommand { Id = id });

            return NoContent();
        }
    }
}
