using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VideoVault.Domain.Extensions;
using VideoVault.Domain.ValidationRules;

namespace VideoVault.Domain.Mapper
{
    public abstract class MappingNode : IMappingNode
    {
        public List<MappingNode> Children { get; set; } = new List<MappingNode>();
        public List<IValidationRule> ValidationRules { get; set; } = new List<IValidationRule>();
        protected abstract dynamic ResolveChildren(MappingData mappingData);
     
        public dynamic Resolve(MappingData mappingData)
        {
            mappingData.Log.LogTrace($"Resolving {GetType().Name}", JsonConvert.SerializeObject(this, Formatting.Indented));

            var result = ResolveChildren(mappingData);

            mappingData.Log.LogTrace($"Resolved {GetType().Name}", new []{ mappingData.GlobalVariables.ToJson(), ToJson(result) });

            foreach (var rule in ValidationRules)
            {
                rule.Validate(mappingData, result);
            }

            return result;
        }

        protected void ConsolidateResolvedResults(dynamic result, ref List<dynamic> resolvedValues)
        {
            if (result is List<dynamic>)
            {
                resolvedValues.AddRange(result);        
            }
            else
            {
                resolvedValues.Add(result);
            }
        }

        private string ToJson(dynamic obj)
        {
            if (obj is KeyValuePair<string, dynamic>)
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }

            if (obj == null)
                return null;

            var type = obj.GetType();
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return obj.ToString();
                case TypeCode.String:
                    return obj;
                default:
                    return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
        }
    }
}