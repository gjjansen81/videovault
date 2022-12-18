using System.Collections.Generic;
namespace VideoVault.Application.Common.Models;

public class SheetTemplateDto
{
    public string Name { get; set; }
    public List<RowTemplateDto> Rows { get; set; }
}