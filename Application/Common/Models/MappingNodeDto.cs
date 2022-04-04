﻿using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class MappingNodeDto
    {
        public string Name { get; set; }
        public List<MappingNodeParameterDto> Parameters { get; set; }
        public string FullName { get; set; }
        public List<MappingNodeDto> Children{ get; set; }
    }
}   