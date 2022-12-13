using System;
using System.ComponentModel.DataAnnotations.Schema;
using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{
    public class CellTemplate : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Index { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Guid DataSourceGuid { get; set; }
    }
}
