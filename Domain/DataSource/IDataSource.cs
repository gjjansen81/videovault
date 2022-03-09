using System;
using System.Collections.Generic;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.DataSource
{
    public interface IDataSource
    {
        Guid Guid { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        RootNode Mapper { get; set; }
        List<dynamic> Result { get; set; }
        
        List<dynamic> Resolve(MappingData mappingData);
    }
}
