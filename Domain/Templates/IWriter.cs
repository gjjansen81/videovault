using System.Collections.Generic;
using NPOI.SS.UserModel;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates
{
    public interface IWriter
    {
        void CreateWorkbook();
        ISheet CreateSheet(string name);
        IRow CreateRow(ISheet sheet, int row);
        ICell CreateCell(IRow row, int column, string value);
    }
}