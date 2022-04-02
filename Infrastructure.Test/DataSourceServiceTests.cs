using AutoMapper;
using Infrastructure.DataSources;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoVault.Application.Common.Mappings;

namespace Infrastructure.Test
{
    [TestClass]
    public class DataSourceServiceTests
    {
        [TestMethod]
        public void GetMappingNodesTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("VideoVaultDb");
            var context = new ApplicationDbContext(optionsBuilder.Options, null, null, null);
    
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InfrastructureMappingProfile());
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            var dataSourceService = new DataSourceService(context, mapper);
            var nodes = dataSourceService.GetMappingNodes();
        }
    }
}