using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoVault.Domain.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastChangedOn { get; set; }
    }
}
