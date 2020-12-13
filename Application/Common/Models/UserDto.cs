using System;
using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public CustomerDto Customer { get; set; }
        public List<string> Roles { get; set; }
    }
}
