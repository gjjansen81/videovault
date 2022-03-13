using System.Collections.Generic;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public interface IRowTemplate
{
    int Index { get; set; }
    List<ICellTemplate> Cells { get; set; }
    void Export(IWriter writer, List<IDataSource> dataSources, ExportData exportData);
}