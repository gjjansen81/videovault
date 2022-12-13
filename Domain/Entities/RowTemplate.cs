using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{
    public class RowTemplate : AuditableEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Index { get; set; }
        public List<CellTemplate> Cells
        {
            get; set;
        }
    }
}