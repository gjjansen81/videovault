using System;
using System.Collections.Generic;
using System.Linq;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public class CellTemplate : ICellTemplate
{
    public int Index { get; set; }

    public int Width{ get; set; }
    public int Height{ get; set; }

    public Guid DataSourceGuid{ get; set; }

    public void Export(IWriter writer, List<IDataSource> dataSources, ExportData exportData)
    {
        var values = dataSources.FirstOrDefault(x => x.Guid == DataSourceGuid)?.Result;

        if (values == null)
            return;

        if (values.GetType() == typeof(List<List<dynamic>>))
        {
            ExportTable(writer, exportData, values);
        }
        else if (values.GetType() == typeof(List<dynamic>))
        {
            ExportRow(writer, exportData, values);
        }
    }

    private void ExportTable(IWriter writer, ExportData exportData, List<dynamic> values)
    {
        var currentRow = exportData.Row;
        int rowIndex = exportData.CurrentRowIndex;
        foreach (var rowValue in values)
        {
            if (rowIndex > exportData.CurrentRowIndex)
                currentRow = writer.CreateRow(exportData.Sheet, rowIndex);
            rowIndex++;

            if (rowValue is List<dynamic>)
            {
                var columnIndex = 0;
                foreach (var columnValue in rowValue)
                {
                    writer.CreateCell(currentRow, Index + columnIndex, columnValue);
                    columnIndex++;
                }
            }
            else
            {
                writer.CreateCell(exportData.Row, Index, rowValue);
            }
        }
    }

    private void ExportRow(IWriter writer, ExportData exportData, List<dynamic> values)
    {
        foreach (var value in values)
        {
            writer.CreateCell(exportData.Row, Index, value);
        }
    }
}