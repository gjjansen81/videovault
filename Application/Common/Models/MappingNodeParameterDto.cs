using System;
using VideoVault.Domain.Enums;

namespace VideoVault.Application.Common.Models;

public class MappingNodeParameterDto
{
    private dynamic _value = null;
    public string Name { get; set; }
    public DataType DateType { get; set; }

    public dynamic Value
    {
        get
        {
            switch (DateType)
            {
                case DataType.Bool:
                    return (bool?) _value;
                case DataType.Int:
                    return (int?)_value;
                case DataType.Double:
                    return (double?)_value;
                case DataType.DateTime:
                    return (DateTime?)_value;
                case DataType.String:
                    return (string)_value;
                default:
                    return _value;
            }
        }
        set
        {
            if (value == null)
                _value = null;

            switch (DateType)
            {
                case DataType.Bool:
                    _value = (bool?) value;
                    break;
                case DataType.Int:
                    _value = (int?) value;
                    break;
                case DataType.Double:
                    _value = (double?) value;
                    break;
                case DataType.DateTime:
                    _value = (DateTime?)value;
                    break;
                case DataType.String:
                    _value = (string) value;
                    break;
                default:
                    _value = value; 
                    break;
            }
        }
    }

    public string Description { get; set; }
    public string Placeholder { get; set; }
}