using System;
using System.Collections.Generic;
using System.Linq;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public class TemplateCell : ITemplateCell
{
    private Guid _dataSourceGuid { get; set; }

    public void Export(int row, int column, List<IDataSource> dataSources, IWriter writer)
    {
        var values = dataSources.FirstOrDefault(x => x.Guid == _dataSourceGuid)?.Result;

        if(values != null)
            return;

        foreach (var value in values)
        {
            writer.Write(row, column, value.ToString());
        }
    }
}