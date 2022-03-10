using System.Collections.Generic;

namespace VideoVault.Domain.Templates;

public interface ISheetTemplate
{
    string Name { get; set; }
    List<IRowTemplate> Rows { get; set; }
}