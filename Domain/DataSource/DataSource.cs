using System;
using System.Collections.Generic;
using NPOI.HPSF;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.DataSource
{
    public class DataSource : IDataSource
    {
        public Guid Guid{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RootNode Mapper { get; set; }
        public List<dynamic> Result { get; set; } = null;

        public List<dynamic> Resolve(MappingData mappingData)
        {
            Result = Mapper.Resolve(mappingData);
            return Result;
        }
    }
}
