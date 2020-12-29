using System;
using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public List<string> Roles { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
