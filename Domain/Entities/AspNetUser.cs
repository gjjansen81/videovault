using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{
    public class AspNetUser : AuditableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}