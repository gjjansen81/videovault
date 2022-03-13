using NPOI.SS.UserModel;

namespace VideoVault.Domain.Templates;

public class ExportData
{
    public ISheet Sheet { get; set; }
    public IRow Row { get; set; }
    public int CurrentRowIndex { get; set; }
}