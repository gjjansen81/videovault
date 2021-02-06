using System.ComponentModel.DataAnnotations.Schema;
using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; } = new Address();
    }
}
