using Microsoft.AspNetCore.Identity;
using VideoVault.Domain.Entities;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        // Your Extended Properties
        public Customer Customer { get; set; }
    }
}
