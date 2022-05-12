using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;
using VideoVault.Domain.Templates;
using Template = VideoVault.Domain.Entities.Template;

namespace Infrastructure.Templates
{
    public class TemplateService : ITemplateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TemplateService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TemplateDto>> GetAsync()
        {
            return _mapper.Map<List<TemplateDto>>(await _context.Templates.ToListAsync());
        }

        public async Task<TemplateDto> GetSingleAsync(int id)
        {
            return _mapper.Map<TemplateDto>(await _context.Templates
                .FirstOrDefaultAsync(x => x.Id ==id));
        }

        public async Task<TemplateDto> UpsertAsync(TemplateDto templateDto)
        {
            var template = _mapper.Map<Template>(templateDto);
            Template entity;
            if (template.Id != 0)
            {
                //_context.Customers.Update(customer);
                entity = await _context.Templates.FirstOrDefaultAsync(x => x.Id == template.Id);

                // Validate entity is not null
                if (entity != null)
                {
                    _context.Entry(entity).CurrentValues.SetValues(template);
                }
            }
            else
            {
                entity = (await _context.Templates.AddAsync(template)).Entity;
            }

            await _context.CommitTransactionAsync();
            return _mapper.Map<TemplateDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Templates.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
                _context.Templates.Remove(entity);
        }
    }
}
