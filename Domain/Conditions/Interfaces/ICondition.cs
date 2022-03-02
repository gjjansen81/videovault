namespace VideoVault.Domain.Conditions.Interfaces
{
    public interface ICondition
    {
        bool Evaluate(MappingData mappingData, dynamic value);
    }
}