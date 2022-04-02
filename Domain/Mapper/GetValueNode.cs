using System.ComponentModel;

namespace VideoVault.Domain.Mapper
{
    public class GetValueNode : MappingNode
    {
        [Description("The value")]
        public string Value { get; set; }

        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            return Value;
        }
    }
}