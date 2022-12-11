using System.Collections.Generic;
using System.Threading.Tasks;
using VideoVault.Application.Common.Models;

namespace VideoVault.Application.Common.Interfaces
{
    public interface ITemplateService
    {
        Task<List<SpreadSheetTemplateDto>> GetAsync();
        Task<SpreadSheetTemplateDto> GetSingleAsync(int id);
        Task<SpreadSheetTemplateDto> UpsertAsync(SpreadSheetTemplateDto spreadSheetTemplate);
        Task DeleteAsync(int id);
        Task<SpreadSheetTemplateDto> AddSheetAsync(SpreadSheetTemplateDto spreadSheetTemplateDto, string sheetName);
    }
}