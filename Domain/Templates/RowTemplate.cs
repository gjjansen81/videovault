using System.Collections.Generic;

namespace VideoVault.Domain.Templates;

class RowTemplate : IRowTemplate
{
    public int RowIndex { get; set; }
    public List<ICellTemplate> Cells { get; set; }
}