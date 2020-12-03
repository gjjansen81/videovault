using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public Task<List<Customer>> GetCustomersAsync()
        {
            return _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync<VideoVault.Domain.Entities.Customer>(x => x.Id ==id );
        }

        public async Task<Customer> UpsertCustomerAsync(Customer customer)
        {
            EntityEntry<Customer> entity;
            if (customer.Id != 0)
                entity = _context.Customers.Update(customer);
            else 
                entity = await _context.Customers.AddAsync(customer);
            
            return entity.Entity;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
                _context.Customers.Remove(entity);
        }
    }
}
