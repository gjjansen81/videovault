using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using VideoVault.Domain.Entities;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        // Your Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<IdentityRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
