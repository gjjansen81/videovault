using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using VideoVault.Application.Common.Interfaces;
using VideoVault.Domain.Entities;

namespace Infrastructure.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync<VideoVault.Domain.Entities.Customer>(x => x.Id ==id );
        }
    }
}
