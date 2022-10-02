using System.Collections.Generic;

namespace VideoVault.Application.Common.Models
{
    public class SpreadSheetTemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SheetTemplateDto> Sheets { get; set; }
        public List<DataSourceDto> DataSources { get; set; }
    }
}
