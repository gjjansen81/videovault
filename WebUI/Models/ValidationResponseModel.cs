using System.Collections.Generic;

namespace VideoVault.WebUI.Models
{
    public class ValidationResponseModel
    {
        public string Message { get; set; }
        public Dictionary<string, List<string>>  ModelState { get; set; }
    }
}
