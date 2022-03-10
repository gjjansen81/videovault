﻿using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates;

public class Template : ITemplate
{
    public List<ISheetTemplate> Sheets { get; set; }
    public List<IDataSource> DataSources { get; set; }

    public void Export(MappingData mappingData, IWriter writer)
    {
        foreach (var dataSource in DataSources)
        {
            dataSource.Resolve(mappingData);
        }

        foreach (var row in Table)
        {
            foreach (var cell in row.Value)
            {
                cell.Value.Export(row.Key, cell.Key, DataSources, writer);
            }
        }
    }
}