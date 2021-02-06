using System.ComponentModel.DataAnnotations.Schema;
using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{
    [Table("AspNetUsers")]
    public class User : AuditableEntity
    {
        public string Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}