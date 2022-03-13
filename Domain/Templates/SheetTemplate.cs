using System.Collections.Generic;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public class SheetTemplate : ISheetTemplate
{
    public string Name { get; set; }
    public List<IRowTemplate> Rows { get; set; }

    public void Export(IWriter writer, List<IDataSource> dataSources, ExportData exportData)
    {
        exportData.Sheet = writer.CreateSheet(Name);
        foreach (var row in Rows)
        {
            row.Export(writer, dataSources, exportData);
        }
    }
}