namespace VideoVault.Domain.Mapper
{
    public class GetValueNode : MappingNode
    {
        public string Value { get; set; }

        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            return Value;
        }
    }
}