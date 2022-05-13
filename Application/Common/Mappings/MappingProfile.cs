using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;

namespace VideoVault.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateDto, Template>();
            CreateMap<DataSource, DataSourceDto>();
            CreateMap<DataSourceDto, DataSource>();
            //ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }
    
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping") 
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
                
                methodInfo?.Invoke(instance, new object[] { this });

            }
        }
    }
}