using System;
using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class MappingNodeDto
    {
        public Guid Guid { get; set; } 
        public string Name { get; set; }
        public string AssemblyName { get; set; }
        public string FullName { get; set; }
        public string FriendlyName { get; set; }
        public List<MappingNodeParameterDto> Parameters { get; set; }
        public List<MappingNodeDto> Children { get; set; } = new List<MappingNodeDto>();
    }
}   