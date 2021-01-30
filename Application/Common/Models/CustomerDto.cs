using System;
using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public List<UserDto> Users { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastChangedOn { get; set; }
    }
}
