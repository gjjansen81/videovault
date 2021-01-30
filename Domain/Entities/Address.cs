using VideoVault.Domain.Common;

namespace VideoVault.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberExtension { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}