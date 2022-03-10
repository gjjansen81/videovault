using System.Collections.Generic;

namespace VideoVault.Domain.Templates;

public class SheetTemplate : ISheetTemplate
{
    public string Name { get; set; }
    public List<IRowTemplate> Rows { get; set; }
}