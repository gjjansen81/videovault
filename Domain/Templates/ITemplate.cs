using System.Collections.Generic;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates
{
    public interface ITemplate
    {
        List<ISheetTemplate> Sheets { get; set; }
        List<IDataSource> DataSources { get; set; }

        public void Export(MappingData mappingData, IWriter writer);
    }
}
