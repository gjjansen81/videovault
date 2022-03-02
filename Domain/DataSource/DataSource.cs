using System.Collections.Generic;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.DataSource
{
    internal class DataSource : IDataSource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RootNode Mapper { get; set; }

        public List<dynamic> Evaluate()
        {
            return Mapper.Resolve(new MappingData());
        }
    }
}
