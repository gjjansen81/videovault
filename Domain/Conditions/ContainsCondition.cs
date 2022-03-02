using System.Collections.Generic;
using VideoVault.Domain.Conditions.Interfaces;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.Conditions
{
    public class ContainsCondition : ICondition
    {
        public List<MappingNode> List { get; set; }
        public MappingNode Value { get; set; }
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            var list = new List<dynamic>();
            foreach (var child in List)
            {
                var result = child.Resolve(mappingData);
                if (result != null)
                {
                    list.Add(result);
                }
            }
            
            if (list.Count == 0) return false;

            var value = Value.Resolve(mappingData);

            if (list is List<dynamic> objects)
            {
                return objects.Contains(value);
            }

            return false;
        }
    }
}