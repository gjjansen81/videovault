using System.Collections.Generic;
using VideoVault.Domain.DataSource;

namespace VideoVault.Domain.Templates
{
    internal interface ITemplate
    {
        Dictionary<int, Dictionary<int, ITemplateCell>> Table { get; set; }
        List<IDataSource> DataSources { get; set; }

        public void Export(IWriter writer);
    }
}
