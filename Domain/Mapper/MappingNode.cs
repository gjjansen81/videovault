using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VideoVault.Domain.Extensions;
using VideoVault.Domain.ValidationRules;

namespace VideoVault.Domain.Mapper
{
    public abstract class MappingNode
    {
        public List<MappingNode> Children { get; set; } = new List<MappingNode>();
        public List<IValidationRule> ValidationRules { get; set; } = new List<IValidationRule>();
        protected abstract dynamic ResolveChildren(MappingData mappingData);
     
        public dynamic Resolve(MappingData mappingData)
        {
            mappingData.Log.LogTrace($"Resolving {GetType().Name}", inputData: JsonConvert.SerializeObject(this, Formatting.Indented));

            var result = ResolveChildren(mappingData);

            mappingData.Log.LogTrace($"Resolved {GetType().Name}", inputData: mappingData.GlobalVariables.ToJson(), outputData: ToJson(result));

            foreach (var rule in ValidationRules)
            {
                rule.Validate(mappingData, result);
            }

            return result;
        }

        protected void ConsolidateResolvedResults(dynamic result, ref Dictionary<string, dynamic> resolvedValues)
        {
            if (result is KeyValuePair<string, dynamic>)
            {
                if (!resolvedValues.ContainsKey(result.Key))
                {
                    resolvedValues[result.Key] = result.Value;
                }
                else if (resolvedValues.TryGetValue(result.Key, out dynamic resolvedValue) && resolvedValue == null)
                {
                    resolvedValues[result.Key] = result.Value;
                }
            }
            else if (result is List<dynamic>)
            {
                foreach (var item in result)
                {
                    if (item is KeyValuePair<string, dynamic>)
                    {
                        if (!resolvedValues.ContainsKey(item.Key))
                        {
                            resolvedValues[item.Key] = item.Value;
                        }
                        else if (resolvedValues.TryGetValue(item.Key, out dynamic resolvedValue) && resolvedValue == null)
                        {
                            resolvedValues[item.Key] = item.Value;
                        }
                    }
                    else if (item is Dictionary<string, dynamic>)
                    {
                        foreach (var subItem in item)
                        {
                            if (!resolvedValues.ContainsKey(subItem.Key))
                            {
                                resolvedValues[subItem.Key] = subItem.Value;
                            }
                            else if (resolvedValues.TryGetValue(subItem.Key, out dynamic resolvedValue) && resolvedValue == null)
                            {
                                resolvedValues[subItem.Key] = subItem.Value;
                            }
                        }
                    }
                }
            }
            else if (result?.GetType() == typeof(Dictionary<string, dynamic>))
            {
                foreach (var item in (Dictionary<string, dynamic>)result)
                {
                    if (!resolvedValues.ContainsKey(item.Key))
                        resolvedValues[item.Key] = item.Value;
                }
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