using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using VideoVault.Domain.ValidationRules;

namespace VideoVault.Domain
{
    public class MappingData
    {
        public IMappingSource Source { get; set; }
        public Dictionary<string, dynamic> GlobalVariables { get; set; } = new Dictionary<string, dynamic>();
        public Dictionary<string, dynamic> LocalVariables { get; set; } = new Dictionary<string, dynamic>();

        public ILogger Log { get; set; }

        public IFormatProvider SourceCultureSettings { get; set; }
        public IFormatProvider DestinationCultureSettings { get; set; }
        public List<ValidationResultModel> ValidationResults { get; set; } = new List<ValidationResultModel>();
    }
}
