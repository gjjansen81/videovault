using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public class SpreadSheetTemplate : ITemplate
{
    public List<ISheetTemplate> Sheets { get; set; }
    public List<IDataSource> DataSources { get; set; }

    public void Export(MappingData mappingData, IWriter writer)
    {
        foreach (var dataSource in DataSources)
        {
            dataSource.Resolve(mappingData);
        }
        writer.CreateWorkbook();
        foreach (var sheet in Sheets)
        {
            var exportData = new ExportData();
            sheet.Export(writer, DataSources, exportData);
        }
    }
}