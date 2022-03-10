using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace VideoVault.Domain.Templates;

public class ExcelWriter : IWriter
{
    private XSSFWorkbook _workbook;

    public void WriteWorkbook()
    {
        _workbook = new XSSFWorkbook();

    }
    public ISheet WriteSheet(string name)
    {
        return _workbook.GetSheet(name) ?? _workbook.CreateSheet(name);
    }

    public IRow WriteRow(ISheet sheet, int row)
    {
        return sheet.GetRow(row) ?? sheet.CreateRow(row);
    }

    public ICell WriteCell(IRow row, int column, string value)
    {
        var font = (XSSFFont)_workbook.CreateFont();
        font.FontHeightInPoints = 11;
        font.FontName = "Calibri";

        var style = (XSSFCellStyle)_workbook.CreateCellStyle();
        style.SetFont(font);
        style.VerticalAlignment = VerticalAlignment.Center;
        style.Alignment = HorizontalAlignment.Right;
       // _cellStyle.DataFormat = _workbook.CreateDataFormat().GetFormat(_valutaFormat);

        ICell cell = row.CreateCell(column);
        cell.SetCellValue(value);
        cell.CellStyle = style;
        return cell;
    }
}