using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface ITemplateService
    {
        Task<List<TemplateDto>> GetAsync();
        Task<TemplateDto> GetSingleAsync(int id);
        Task<TemplateDto> UpsertAsync(TemplateDto customer);
        Task DeleteAsync(int id);
    }
}