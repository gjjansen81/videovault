using Newtonsoft.Json.Linq;
using NPOI.XSSF.UserModel;
using System.IO;

namespace VideoVault.Domain;

public class ExcelMappingSource : IMappingSource
{
    private XSSFWorkbook _source;

    public ExcelMappingSource(string filePath)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        using (fileStream)
        {
            _source = new XSSFWorkbook(fileStream);
        }
    }

    public dynamic GetValue(ICoordinate coordinate, bool errorWhenNoMatch = false)
    {
        var cell = _source.GetSheet(coordinate.SheetName)?.GetRow(coordinate.RowIndex)?.GetCell(coordinate.ColumnIndex);
        var value = cell?.StringCellValue;
        return value;
    }
}