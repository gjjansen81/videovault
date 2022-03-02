using VideoVault.Domain.Conditions.Interfaces;
using VideoVault.Domain.Helpers;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.Conditions
{
    public class BetweenCondition : ICondition
    {
        public MappingNode Min { get; set; }
        public MappingNode Max { get; set; }
        public MappingNode Value { get; set; }
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            var min = Min.Resolve(mappingData);
            var max = Max.Resolve(mappingData);
            var value = Value.Resolve(mappingData);
            
            var minType = min.GetType();
            var maxType = max.GetType();
            var valueType = value.GetType();
            
            if (DataTypeTools.IsNumeric(minType) && DataTypeTools.IsNumeric(maxType) && DataTypeTools.IsNumeric(valueType))
            {
                return min <= value && value <= max;
            }

            return false;
        }
    }
}