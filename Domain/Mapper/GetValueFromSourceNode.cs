using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace VideoVault.Domain.Mapper
{
    public class GetValueFromSourceNode : MappingNode
    {
        public string PropertyName { get; set; }
        public bool ForceUseSource { get; set; } = false;
        public bool TryParseToNumber { get; set; } = true;
        public bool ConvertToString { get; set; } = false;
        public bool Trim { get; set; } = false;
        public MappingNode PropertyNode { get; set; }

        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            var source = ForceUseSource ? mappingData.Source : mappingData.CurrentElement;

            if (source == null)
                return null;
            
            if (PropertyNode != null)
                PropertyName = PropertyNode.Resolve(mappingData)?.ToString();

            JToken value = source.SelectToken(PropertyName, errorWhenNoMatch: false);

            if (value?.Type == JTokenType.Integer)
            {
                if (ConvertToString)
                {
                    return value.Value<int>().ToString(mappingData.DestinationCultureSettings);
                }
                return value.Value<int>();
            }
            else  if (value?.Type == JTokenType.Float )
            {
                if (ConvertToString)
                {
                    return value.Value<decimal>().ToString(mappingData.DestinationCultureSettings);
                }
                return value.Value<decimal>();
            }

            var valueString = value?.ToString();

            if (TryParseToNumber && Decimal.TryParse(valueString, NumberStyles.Any, mappingData.SourceCultureSettings, out var parsedValue))
            {
                if (ConvertToString)
                    return parsedValue.ToString(mappingData.DestinationCultureSettings);
                return parsedValue;
            }
            if (Trim)
                return valueString?.Trim();

            return valueString;
        }
    }
}