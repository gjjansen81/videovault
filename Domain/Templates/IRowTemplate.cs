using System.Collections.Generic;

namespace VideoVault.Domain.Templates;

public interface IRowTemplate
{
    int RowIndex { get; set; }
    List<ICellTemplate> Cells { get; set; }
}