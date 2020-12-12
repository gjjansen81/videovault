using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<CustomerDto> UpsertCustomerAsync(CustomerDto customer);
        Task DeleteCustomerAsync(int id);
    }
}