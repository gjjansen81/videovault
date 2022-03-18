using System;
using System.Text.Json.Nodes;

namespace VideoVault.Application.Common.Models
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TemplateJson { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastChangedOn { get; set; }
    }
}
