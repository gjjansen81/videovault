using System.Collections.Generic;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public class RowTemplate : IRowTemplate
{
    public int Index { get; set; }
    public List<ICellTemplate> Cells { get; set; }

    public void Export(IWriter writer, List<IDataSource> dataSources, ExportData exportData)
    {
        exportData.CurrentRowIndex = Index;
        exportData.Row = writer.CreateRow(exportData.Sheet, Index);
        foreach (var cell in Cells)
        {
            cell.Export(writer, dataSources, exportData);
        }
    }
}