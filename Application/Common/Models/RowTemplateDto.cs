using System.Collections.Generic;

namespace VideoVault.Application.Common.Models;

public class RowTemplateDto
{
    public int Index { get; set; }
    public List<CellTemplateDto> Cells { get; set; }
}