namespace VideoVault.Domain;

public class ExcelCoordinate : ICoordinate
{
    public string SheetName { get; set; }
    public int ColumnIndex { get; set; }
    public int RowIndex { get; set; }

    public ExcelCoordinate(string sheetName, int columnIndex, int rowIndex)
    {
        this.SheetName = sheetName;
        this.ColumnIndex = columnIndex;
        this.RowIndex = rowIndex;
    }
}