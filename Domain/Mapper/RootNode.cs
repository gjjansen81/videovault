using System.Collections.Generic;

namespace VideoVault.Domain.Mapper
{
    public class RootNode : MappingNode
    {
        public string Name { get; set; }
        public int Entity { get; set; }
        public string Destination { get; set; }

        protected override dynamic ResolveChildren(MappingData mappingData)
        {
            var results = new List<dynamic>();
            foreach (var child in Children)
            {
                var resolvedChild = child.Resolve(mappingData);
                ConsolidateResolvedResults(resolvedChild, ref results); ;
            }

            return results;
        }
    }
}