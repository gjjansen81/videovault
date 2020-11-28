using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Domain.Entities;

namespace VideoVault.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Task<Customer> GetCustomerAsync(int id);
    }
}