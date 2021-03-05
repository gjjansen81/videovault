using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using VideoVault.Domain.Entities;

namespace Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<ApplicationUser> AspNetUsers {  get; set; }
        public DbSet<Customer> Customers { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
