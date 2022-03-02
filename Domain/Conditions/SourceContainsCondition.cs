using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.Conditions
{
    public class SourceContainsCondition : ICondition
    {
        public string Key { get; set; }
        
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            if(mappingData.CurrentElement.GetType() == typeof(JObject))
            {
                IEnumerable<JToken> value = mappingData.CurrentElement.SelectTokens(Key);
                if (value != null)
                {
                    foreach(var val in value.ToList())
                    {
                        if (!string.IsNullOrWhiteSpace(val.ToString()))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            return false;
        }
    }
}