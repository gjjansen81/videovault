using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.Conditions
{
    public class ResultingChildContainsCondition : ICondition
    {
        public string Key { get; set; }
        
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            if (evaluationData == null)
                return false;

            if (evaluationData.GetType() == typeof(Dictionary<string, dynamic>))
            {
                var typedValue = (Dictionary<string, dynamic>)evaluationData;
                if (typedValue.ContainsKey(Key) && typedValue.TryGetValue(Key, out var value))
                {
                    if (value is string)
                        return !string.IsNullOrWhiteSpace(value);

                    if (value is List<dynamic>)
                        return value.Count > 0;

                    return value != null;
                }
            }

            if (evaluationData.GetType() == typeof(JObject))
            {
                JToken value = evaluationData.SelectToken(Key, errorWhenNoMatch: false);
                if (value == null)
                    return false;

                return !string.IsNullOrWhiteSpace(value.ToString());
            }

            return false;
        }
    }
}