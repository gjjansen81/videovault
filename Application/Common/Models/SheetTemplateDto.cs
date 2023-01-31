using System.Collections.Generic;
namespace VideoVault.Application.Common.Models;

public class SheetTemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<RowTemplateDto> Rows { get; set; }
}