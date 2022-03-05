namespace VideoVault.Domain;

public interface ICoordinate
{
    string SheetName { get; set; }
    int ColumnIndex { get; set; }
    int RowIndex { get; set; }
}