using System.Collections.Generic;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public interface ISheetTemplate
{
    string Name { get; set; }
    List<IRowTemplate> Rows { get; set; }
    void Export(IWriter writer, List<IDataSource> dataSources, ExportData exportData);
}