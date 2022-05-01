using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Common.Attributes;
using VideoVault.Domain.Entities;
using VideoVault.Domain.Enums;
using VideoVault.Domain.Mapper;

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

        public List<MappingNodeDto> GetMappingNodes()
        {
            var type = typeof(IMappingNode);
            var mappingClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .Where(p => p.Name != "IMappingNode" && p.Name != "MappingNode");

            var nodes = new List<MappingNodeDto>();
            foreach (var mappingClass in mappingClasses)
            {
                var assemblyQualifiedName = mappingClass.AssemblyQualifiedName;
                if(assemblyQualifiedName == null) 
                    continue;

                var nodeConfigurableAttribute = (ConfigurableAttribute)mappingClass.GetCustomAttributes(typeof(ConfigurableAttribute), true).FirstOrDefault();
                if (nodeConfigurableAttribute == null)
                    continue;
                
                var nodeDescription = $"{mappingClass.FullName?.Replace(".", "_")}_description";

                var properties = Type.GetType(assemblyQualifiedName)?.GetProperties();
                if (properties == null)
                    continue;

                var parameters = new List<MappingNodeParameterDto>();
                foreach (var property in properties)
                {
                    var configurableAttribute = (ConfigurableAttribute)property.GetCustomAttributes(typeof(ConfigurableAttribute), true).FirstOrDefault();
                    if(configurableAttribute == null)
                        continue;

                    var key = property.DeclaringType?.FullName?.Replace(".", "_") ?? string.Empty;
                    var description = $"{key}_{property.Name}_description";
                    var placeholder = $"{key}_{property.Name}_placeholder";

                    parameters.Add(new MappingNodeParameterDto()
                    {
                        Name = property.Name,
                        Description = description.ToUpper(),
                        Placeholder = placeholder.ToUpper(),
                        DateType = ConvertTypeToDataType(property.PropertyType)
                    });
                }

                nodes.Add(new MappingNodeDto()
                {
                    Name = mappingClass.Name,
                    FullName = mappingClass.FullName,
                    FriendlyName = nodeDescription.ToUpper(),
                    Parameters = parameters
                });
            }

            return nodes;
        }

        private DataType ConvertTypeToDataType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                //case TypeCode.Byte:
                //case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return DataType.Int;
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return DataType.Double;
                case TypeCode.String:
                    return DataType.String;
                case TypeCode.DateTime:
                    return DataType.DateTime;
                case TypeCode.Boolean:
                    return DataType.Bool;
                default:
                    return DataType.Unknown;
            }

        }
    }
}
