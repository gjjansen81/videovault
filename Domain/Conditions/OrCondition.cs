using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.Conditions
{
    public class OrCondition : ICondition
    {
        public ICondition Condition1 { get; set; }
        public ICondition Condition2 { get; set; }
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            return Condition1.Evaluate(mappingData, evaluationData) || Condition2.Evaluate(mappingData, evaluationData);
        }
    }
}