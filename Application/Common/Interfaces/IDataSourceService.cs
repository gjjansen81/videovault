using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface IDataSourceService
    {
        Task<List<DataSourceDto>> GetAsync();
        Task<DataSourceDto> GetSingleAsync(Guid guid);
        Task<DataSourceDto> UpsertAsync(DataSourceDto dataSource);
        Task DeleteAsync(Guid guid);
    }
}