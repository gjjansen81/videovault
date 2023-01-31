using System;
using System.Text.Json;
using VideoVault.Domain.Enums;

namespace VideoVault.Application.Common.Models;

public class MappingNodeParameterDto
{
    private dynamic _value = null;
    public string Name { get; set; }
    public DataType DataType { get; set; }

    public dynamic Value
    {
        get
        {
            switch (DataType)
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
            if (value is System.Text.Json.JsonElement jsonElement)
            {
                ExtractFromJsonElement(jsonElement);
            }
            else
            {
                ExtractFromDynamic(value);
            }
        }
    }

    private void ExtractFromDynamic(dynamic value)
    {
        if (value == null)
            _value = null;

        switch (DataType)
        {
            case DataType.Bool:
                _value = (bool?)value;
                break;
            case DataType.Int:
                _value = (int?)value;
                break;
            case DataType.Double:
                _value = (double?)value;
                break;
            case DataType.DateTime:
                _value = (DateTime?)value;
                break;
            case DataType.String:
                _value = (string)value;
                break;
            default:
                _value = value;
                break;
        }
    }

    private void ExtractFromJsonElement(JsonElement jsonElement)
    {
        switch (DataType)
        {
            case DataType.Bool:
                _value = jsonElement.GetBoolean();
                break;
            case DataType.Int:
                _value = jsonElement.GetInt32();
                break;
            case DataType.Double:
                _value = jsonElement.GetDouble();
                break;
            case DataType.DateTime:
                _value = jsonElement.GetDateTime();
                break;
            case DataType.String:
                _value = jsonElement.GetString();
                break;
            default:
                _value = jsonElement;
                break;
        }
    }

    public string Description { get; set; }
    public string Placeholder { get; set; }
}