using AutoMapper;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Application.Common.Models;
using VideoVault.Domain;
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
            var dataSource = await _context.DataSources.FirstOrDefaultAsync(x => x.Guid == guid);
            
            var dataSourceDto = _mapper.Map<DataSourceDto>(dataSource);

            var rootNode = new RootNode();
            if (!string.IsNullOrWhiteSpace(dataSource?.Mapper))
            {
                rootNode = ConvertFromJson(dataSource.Mapper);
            }

            dataSourceDto.RootNode = ConvertToMappingNodeDto(rootNode);
           
            return dataSourceDto;
            
        }

        public async Task<DataSourceDto> UpsertAsync(DataSourceDto dataSourceDto)
        {   
            var dataSource = _mapper.Map<DataSource>(dataSourceDto);
            if (dataSourceDto.RootNode != null)
            {
                var mappingNodes = ConvertToMappingNodes(dataSourceDto.RootNode);

                dataSource.Mapper = ConvertToJson(mappingNodes);
            }
            DataSource entity;
            if (dataSource.Guid != Guid.Empty)
            {
                //_context.Customers.Update(customer);
                entity = await _context.DataSources.FirstOrDefaultAsync(x => x.Guid == dataSource.Guid);

                // Validate entity is not null
                if (entity != null)
                {
                    _context.Entry(entity).CurrentValues.SetValues(dataSource);
                    //entity.Name = customer.Name;
                }
            }
            else
            {
                entity = (await _context.DataSources.AddAsync(dataSource)).Entity;
            }

            await _context.CommitTransactionAsync();
            var updatedDataSource = _mapper.Map<DataSourceDto>(entity);
            if (entity?.Mapper != null)
            {
                var mappingNode = ConvertFromJson(entity.Mapper);
                updatedDataSource.RootNode = ConvertToMappingNodeDto(mappingNode);
            }

            return updatedDataSource;
        }

        public string ConvertToJson(MappingNode mappingNodes)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            return JsonConvert.SerializeObject(mappingNodes, settings);
        }

        public RootNode ConvertFromJson(string mappingConfiguration)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            return JsonConvert.DeserializeObject<RootNode>(mappingConfiguration, settings);
        }

        public async Task DeleteAsync(Guid guid)
        {
            var entity = await _context.DataSources.FirstOrDefaultAsync(x => x.Guid == guid);
            if (entity != null)
            {
                _context.DataSources.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public List<MappingNodeDto> GetAvailableMappingNodes()
        {
            var type = typeof(IMappingNode);
            var mappingClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .Where(p => p.Name != "IMappingNode" && p.Name != "MappingNode");

            var nodes = new List<MappingNodeDto>();
            foreach (var mappingClass in mappingClasses)
            {
                var node = InstantiateMappingNodeDto(mappingClass);
                if(node != null)
                    nodes.Add(node);
            }

            return nodes;
        }

        private MappingNodeDto InstantiateMappingNodeDto(Type mappingClass, bool onlyConfigurableAttributes = true, MappingNode mappingNode = null, int depth=0)
        {
            var assemblyQualifiedName = mappingClass.AssemblyQualifiedName;
            if (assemblyQualifiedName == null)
                return null;

            if (onlyConfigurableAttributes)
            {
                var nodeConfigurableAttribute = (ConfigurableAttribute)mappingClass.GetCustomAttributes(typeof(ConfigurableAttribute), true).FirstOrDefault();
                if (nodeConfigurableAttribute == null)
                    return null;
            }

            var nodeDescription = $"{mappingClass.FullName?.Replace(".", "_")}_description";

            var properties = Type.GetType(assemblyQualifiedName)?.GetProperties();
            if (properties == null)
                return null;

            var parameters = new List<MappingNodeParameterDto>();
            foreach (var property in properties)
            {
                var configurableAttribute = (ConfigurableAttribute)property.GetCustomAttributes(typeof(ConfigurableAttribute), true).FirstOrDefault();
                if (configurableAttribute == null)
                    continue;

                var key = property.DeclaringType?.FullName?.Replace(".", "_") ?? string.Empty;
                var description = $"{key}_{property.Name}_description";
                var placeholder = $"{key}_{property.Name}_placeholder";

                var type = property.PropertyType;
                parameters.Add(new MappingNodeParameterDto()
                {
                    Name = property.Name,
                    Description = description.ToUpper(),
                    Placeholder = placeholder.ToUpper(),
                    DataType = ConvertTypeToDataType(property.PropertyType),
                    Value = (mappingNode != null) ? property.GetValue(mappingNode) : null
                });
            }

            return new MappingNodeDto()
            {
                AssemblyName = mappingClass.Assembly.FullName,
                Name = mappingClass.Name,
                FullName = mappingClass.FullName,
                FriendlyName = nodeDescription.ToUpper(),
                Parameters = parameters,
                Guid = mappingNode?.Guid ?? Guid.NewGuid(),
                Depth = depth
            };
        }
        
        public MappingNodeDto ConvertToMappingNodeDto(MappingNode mappingNode, int depth=0)
        {
            var mappingClass = mappingNode.GetType();
            var node = InstantiateMappingNodeDto(mappingClass, false, mappingNode, depth);

            if (string.IsNullOrWhiteSpace(mappingClass.AssemblyQualifiedName))
            {
                return node;
            }

            if (mappingNode.Children.Any())
            {
                depth++;
                node.Children = new List<MappingNodeDto>();
                foreach (var mappingNodeChild in mappingNode.Children)
                {
                    var child = ConvertToMappingNodeDto(mappingNodeChild, depth);
                    if (child != null)
                        node.Children.Add(child);
                }
            }

            return node;
        }
        
        private DataType ConvertTypeToDataType(Type type)
        {
            if (type.IsInterface)
            {
                if (typeof(ICoordinate).IsAssignableFrom(type))
                {
                    return DataType.Coordinate;
                }

                if (typeof(IMappingNode).IsAssignableFrom(type))
                {
                    return DataType.MappingNode;
                }
            }
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

        public MappingNode ConvertToMappingNodes(MappingNodeDto mappingNodeDto)
        {
            ObjectHandle handle = Activator.CreateInstance(mappingNodeDto.AssemblyName, mappingNodeDto.FullName);
            MappingNode node = (MappingNode)handle.Unwrap();
            Type t = node.GetType();
            foreach (var parameter in mappingNodeDto.Parameters)
            {
                PropertyInfo prop = t.GetProperty(parameter.Name);
                if (prop == null)
                    continue;

                if (parameter.DataType == DataType.Coordinate)
                {
                    var jsonString = ((System.Text.Json.JsonElement)parameter.Value).GetString();
                    var value = JsonConvert.DeserializeObject<ExcelCoordinate>(jsonString.ToString());
                    prop.SetValue(node, value);
                }
                else if (parameter.Value != null)
                {
                    prop.SetValue(node, parameter.Value);
                }
            }

            if (mappingNodeDto.Children != null)
            {
                node.Children = new List<MappingNode>();
                foreach (var child in mappingNodeDto.Children)
                {
                    var childNode = ConvertToMappingNodes(child);
                    node.Children.Add(childNode);
                }
            }

            return node;
        }
    }
}
