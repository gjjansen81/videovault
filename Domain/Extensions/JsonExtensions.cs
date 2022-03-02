using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VideoVault.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this Dictionary<string,dynamic> dictionary)
        {
            return JsonConvert.SerializeObject(dictionary, Formatting.Indented);
        }

        public static string ToLocalizedXml(this JObject jObject, string rootElement = "")
        {
            throw new NotImplementedException();
            //var converter = new JsonToXmlConverter();
            //return converter.ToXml(jObject, rootElement);
        }
    }
}
