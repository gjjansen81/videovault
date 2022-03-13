using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public interface ICellTemplate
{
    int Index { get; set; }
    int Width { get; set; }
    int Height { get; set; }
    Guid DataSourceGuid { get; set; }

    void Export(IWriter writer, List<IDataSource> dataSources, ExportData exportData);
}