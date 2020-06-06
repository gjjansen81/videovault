using System;

namespace VideoVault.Application.Common.Models
{
    public class AuthenticationDto
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}