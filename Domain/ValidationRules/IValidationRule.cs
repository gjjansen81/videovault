using VideoVault.Domain.Enums;

namespace VideoVault.Domain.ValidationRules
{
    public interface IValidationRule
    {
        ValidationLevels Level { get; set; }

        void Validate(MappingData mappingData, dynamic validationTarget);
    }
}