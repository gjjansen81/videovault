﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAsync();
        Task<CustomerDto> GetSingleAsync(int id);
        Task<CustomerDto> UpsertAsync(CustomerDto customer);
        Task DeleteAsync(int id);
    }
}