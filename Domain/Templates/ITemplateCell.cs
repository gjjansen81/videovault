using System;
using System.Collections.Generic;
using NPOI.HPSF;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates
{
    public interface ITemplateCell
    {
        void Export(int row, int column, List<IDataSource> dataSources, IWriter writer);
    }
}