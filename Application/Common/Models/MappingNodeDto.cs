using System;
using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class MappingNodeDto
    {
        public string Name { get; set; }
        public List<MappingNodeParameter> Parameters { get; set; }
    }

    public class MappingNodeParameter
    {
        public string Name { get; set; }
        public Type DateType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public enum DateTypeEnum
    {
        Int,
        String,
        Bool
    }
}
