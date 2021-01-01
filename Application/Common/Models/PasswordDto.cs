using System;
using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class PasswordDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
