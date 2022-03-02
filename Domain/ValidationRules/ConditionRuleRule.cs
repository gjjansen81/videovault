using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.ValidationRules
{
    public class ConditionRule : ValidationRule
    {
        public ICondition Condition { get; set; }
        public override void Validate(MappingData mappingData, dynamic validationTarget)
        {
            if(!Condition.Evaluate(mappingData, mappingData.CurrentElement))
                HandleValidationResults(mappingData, $"Condition {Condition.ToString()} doesn't match");
        }
    }
}