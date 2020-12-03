using System;

namespace VideoVault.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name;
        public DateTime? CreatedOn;
        public DateTime? LastChangedOn;

        public Customer()
        {
            
        }

        public Customer(int id = 0, string name= null, DateTime? createdOn = null, DateTime? lastChangedOn = null)
        {
            Id = id;
            Name = name;
            CreatedOn = createdOn;
            LastChangedOn = lastChangedOn;
        }
    }
}
