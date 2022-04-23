using System;
using VideoVault.Domain.Enums;

namespace VideoVault.Application.Common.Models;

public class MappingNodeParameterDto
{
    public string Name { get; set; }
    public DataType DateType { get; set; }
    public IValue Value { get; set; }
    public string Description { get; set; }
    public string Placeholder { get; set; }

    public void SetValue(dynamic value)
    {
        Value = value;
    }
}

public interface IValue
{
    public void SetValue(string value);
    public void SetValue(DateTime value);
    public void SetValue(int value);
}

public class StringValue : IValue
{
    private dynamic _value = null;

    public void SetValue(string value)
    {
        _value = value;
    }

    public void SetValue(DateTime value)
    {
        _value = value;
    }

    public void SetValue(int value)
    {
        _value = value;
    }
}
