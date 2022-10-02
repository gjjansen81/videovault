using System.Collections.Generic;

namespace VideoVault.Domain.Templates;

public class RowTemplateDto 
{
    public int Index { get; set; }
    public List<CellTemplateDto> Cells { get; set; }
}