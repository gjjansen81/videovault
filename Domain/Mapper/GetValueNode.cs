using System.ComponentModel;

namespace VideoVault.Domain.Mapper
{
    [Description("Value - constant")]
    public class GetValueNode : MappingNode
    {
        [Description("The value")]
        public string Value { get; set; }

        [Description("The boolean")]
        public bool TestCheck{ get; set; }
        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            return Value;
        }
    }
}