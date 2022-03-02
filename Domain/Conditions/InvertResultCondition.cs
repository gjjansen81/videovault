using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.Conditions
{
    public class InvertResultCondition : ICondition
    {
        public ICondition Condition { get; set; }

        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            return !Condition.Evaluate(mappingData, evaluationData);
        }
    }
}