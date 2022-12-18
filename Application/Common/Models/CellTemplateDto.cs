using System;

namespace VideoVault.Application.Common.Models;

public class CellTemplateDto
{
    public int Index { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public Guid DataSourceGuid { get; set; }
}