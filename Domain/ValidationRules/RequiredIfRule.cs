using VideoVault.Domain.Conditions.Interfaces;

namespace VideoVault.Domain.ValidationRules
{
    public class RequiredIfRule : RequiredRule
    {
        public ICondition Condition { get; set; }
        public override void Validate(MappingData mappingData, dynamic validationTarget)
        {
            if(Condition.Evaluate(mappingData, validationTarget))
                ValidateEx(mappingData, validationTarget);
        }
    }
}