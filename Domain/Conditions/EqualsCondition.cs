using VideoVault.Domain.Conditions.Interfaces;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.Conditions
{
    public class EqualsCondition : ICondition
    {
        public MappingNode Left{ get; set; }
        public MappingNode Right { get; set; }
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            var result1 = Left.Resolve(mappingData);
            var result2 = Right.Resolve(mappingData);

            if (result1 == null && result2 == null)
                return true;
            if (result1 == null)
                return false;
            if (result2 == null)
                return false;

            if (result1.GetType() == result2.GetType())
                return result1 == result2;

            if (result1.GetType() != result2.GetType())
                return result1.ToString() == result2.ToString();

            return false;
        }
    }
}