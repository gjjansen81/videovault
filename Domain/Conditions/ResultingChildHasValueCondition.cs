using System.Collections.Generic;
using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.Conditions
{
    public class ResultingChildHasValueCondition : ICondition
    {
        public string Key { get; set; }
        public dynamic Value { get; set; }
        
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            if (evaluationData.GetType() == typeof(Dictionary<string, dynamic>))
            {
                var typedValue = (Dictionary<string, dynamic>)evaluationData;
                if (typedValue.ContainsKey(Key) && typedValue.TryGetValue(Key, out var value))
                {
                    return value == Value;
                }
            }

            return false;
        }
    }
}