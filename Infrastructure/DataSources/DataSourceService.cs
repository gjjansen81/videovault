using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;

namespace Infrastructure.DataSources
{
    public class DataSourceService : IDataSourceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DataSourceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DataSourceDto>> GetAsync()
        {
            return _mapper.Map<List<DataSourceDto>>(await _context.DataSources.ToListAsync());
        }

        public async Task<DataSourceDto> GetSingleAsync(Guid guid)
        {
            return _mapper.Map<DataSourceDto>(await _context.DataSources
                .FirstOrDefaultAsync(x => x.Guid ==guid));
        }

        public async Task<DataSourceDto> UpsertAsync(DataSourceDto dataSourceDto)
        {
            var dataSource = _mapper.Map<DataSource>(dataSourceDto);
            DataSource entity;
            if (dataSource.Guid != Guid.Empty)
            {
                //_context.Customers.Update(customer);
                entity = await _context.DataSources.FirstOrDefaultAsync(x => x.Guid == dataSource.Guid);

                // Validate entity is not null
                if (entity != null)
                {
                    entity = dataSource;
                    //entity.Name = customer.Name;
                }
            }
            else
            {
                entity = (await _context.DataSources.AddAsync(dataSource)).Entity;
            }

            await _context.CommitTransactionAsync();
            return _mapper.Map<DataSourceDto>(entity);
        }

        public async Task DeleteAsync(Guid guid)
        {
            var entity = await _context.DataSources.FirstOrDefaultAsync(x => x.Guid == guid);
            if (entity != null)
                _context.DataSources.Remove(entity);
        }
    }
}
