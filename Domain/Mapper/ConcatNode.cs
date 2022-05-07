using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using VideoVault.Domain.Common.Attributes;

namespace VideoVault.Domain.Mapper
{
    [Configurable]
    public class ConcatNode : MappingNode
    {
        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            var results = new List<dynamic>();
            foreach (var child in Children)
            {
                var result = child.Resolve(mappingData);
                if (Regex.IsMatch(result, @"^\d+$"))
                {
                    results.Add(result.ToString());
                }
                else if (result is string)
                {
                    results.Add(result);
                }
                else
                {
                    mappingData.Log.LogDebug($"Skipping value {result} as the type is not supported by concat node");
                }
            }
            var concatResult = string.Concat(results);
            mappingData.Log.LogDebug($"Result of concat node: {concatResult}");
            return concatResult;
        }
    }
}