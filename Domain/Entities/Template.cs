using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{   
    public class Template : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SheetTemplate> Sheets { get; set; } = new List<SheetTemplate>();
    }
}
