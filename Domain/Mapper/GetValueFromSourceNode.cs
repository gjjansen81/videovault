using System;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json.Linq;
using VideoVault.Domain.Common.Attributes;

namespace VideoVault.Domain.Mapper
{
    [Configurable]
    public class GetValueFromSourceNode : MappingNode
    {
        [Configurable]
        public ICoordinate Coordinate { get; set; }
        //public bool ForceUseSource { get; set; } = false;

        [Configurable]
        public bool TryParseToNumber { get; set; } = true;

        [Configurable]
        public bool ConvertToString { get; set; } = false;

        [Configurable]
        public bool Trim { get; set; } = false;

        [Configurable]
        public MappingNode PropertyNode { get; set; }

        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            var source = mappingData.Source;//ForceUseSource ? mappingData.Source : mappingData.CurrentElement;

            if (source == null)
                return null;
            
            if (PropertyNode != null)
                Coordinate = PropertyNode.Resolve(mappingData)?.ToString();

            dynamic value = source.GetValue(Coordinate, errorWhenNoMatch: false);

            /*
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
            */
            var valueString = value?.ToString();
            decimal parsedValue = 0;
            if (TryParseToNumber && Decimal.TryParse(valueString, NumberStyles.Any, mappingData.SourceCultureSettings, out parsedValue))
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