using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VideoVault.Domain.ValidationRules;

namespace VideoVault.Domain
{
    public class MappingData
    {
        private JObject _currentElement;

        public JObject Source { get; set; }
        public Dictionary<string, dynamic> GlobalVariables { get; set; } = new Dictionary<string, dynamic>();
        public Dictionary<string, dynamic> LocalVariables { get; set; } = new Dictionary<string, dynamic>();

        public ILog Log { get; set; }

        public IFormatProvider SourceCultureSettings { get; set; }
        public IFormatProvider DestinationCultureSettings { get; set; }
        public List<ValidationResultModel> ValidationResults { get; set; } = new List<ValidationResultModel>();

        public JObject CurrentElement
        {
            get => _currentElement ?? Source;
            set => _currentElement = value;
        }

        public string OrderNumber { get; set; }
        public int RequestID { get; set; } 
        public int? RecordID { get; set; }
        public int? RecordEntity { get; set; }
    }
}
