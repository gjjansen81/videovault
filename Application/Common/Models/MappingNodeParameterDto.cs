using System;

namespace VideoVault.Application.Common.Models;

public class MappingNodeParameterDto
{
    public string Name { get; set; }
    public Type DateType { get; set; }
    public dynamic Value { get; set; }
    public string Description { get; set; }
}