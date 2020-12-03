using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Domain.Entities;

namespace VideoVault.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> UpsertCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}