using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.DataSource
{
    internal interface IDataSource
    {
        string Name { get; set; }
        string Description { get; set; }
        RootNode Mapper { get; set; }
    }
}
