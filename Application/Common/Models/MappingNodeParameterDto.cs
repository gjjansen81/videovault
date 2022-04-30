using System;
using VideoVault.Domain.Enums;

namespace VideoVault.Application.Common.Models;

public class MappingNodeParameterDto
{
    public string Name { get; set; }
    public DataType DateType { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }
    public string Placeholder { get; set; }
}