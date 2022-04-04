using System;

namespace VideoVault.Application.Common.Models
{
    public class DataSourceDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MappingNodeDto RootNode { get; set; }
    }
}
