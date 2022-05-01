using System.ComponentModel;
using VideoVault.Domain.Common.Attributes;

namespace VideoVault.Domain.Mapper
{
    [Configurable]
    public class GetValueNode : MappingNode
    {
        [Configurable]
        public string Value { get; set; }
        
        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            return Value;
        }
    }
}