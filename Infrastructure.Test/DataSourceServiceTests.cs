using AutoMapper;
using Infrastructure.DataSources;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VideoVault.Application.Common.Mappings;
using VideoVault.Domain.Mapper;

namespace Infrastructure.Test
{
    [TestClass]
    public class DataSourceServiceTests
    {
        private readonly RootNode _testRoot = new RootNode()
        {
            Children = new List<MappingNode>()
            {
                new ConcatNode()
                {
                    Children = new List<MappingNode>()
                    {

                        new GetValueNode()
                        {
                            Value = "A1"
                        },

                        new GetValueNode()
                        {
                            Value = "B2"
                        }
                    }
                }
            }
        };

        private DataSourceService _dataSourceService = null;

        [TestInitialize]
        public void TestInit()
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
            _dataSourceService = new DataSourceService(context, mapper);

        }

        [TestMethod]
        public void GetAvailableMappingNodesTests()
        {
            var result = _dataSourceService.GetAvailableMappingNodes();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 2);
            Assert.IsTrue(result.Any(x => x.FullName.Contains("GetValueNode")));
            Assert.IsTrue(!result.Any(x => x.FullName.Contains("RootNode")));
        }

        [TestMethod]
        public void ConvertToMappingNodesTests()
        {
            var rootNode = _dataSourceService.ConvertToMappingNodeDto(_testRoot);
            var result = _dataSourceService.ConvertToMappingNodes(rootNode);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Children.Count == 1);
            Assert.IsTrue(result.Children.First().Children.Count == 2);
            Assert.IsTrue(result.Children.Any(x => x is ConcatNode));
            Assert.IsTrue(result.Children.First().Children.All(x => x is GetValueNode));
        }

        [TestMethod]
        public void ConvertToMappingNodeDtoTests()
        {
            var result = _dataSourceService.ConvertToMappingNodeDto(_testRoot);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Children.Count == 1);
            Assert.IsTrue(result.Children[0].Children.Count == 2);

            Assert.IsTrue(result.FullName.Contains("RootNode"));
            Assert.IsTrue(!result.Children.Any(x => x.FullName.Contains("GetValueNode")));
            Assert.IsTrue(result.Children.All(x => x.FullName.Contains("ConcatNode")));
            Assert.IsTrue(result.Children.First().Children.All(x => x.FullName.Contains("GetValueNode")));
            var child1 = result.Children.First().Children[0].Parameters.Where(x => x.Name.Equals("Value", StringComparison.InvariantCultureIgnoreCase)).ToList().First();
            var child2 = result.Children.First().Children[1].Parameters.Where(x => x.Name.Equals("Value", StringComparison.InvariantCultureIgnoreCase)).ToList().First();
            Assert.IsTrue(child1.Value.Equals("A1"));
            Assert.IsTrue(child2.Value.Equals("B2"));
        }

    }
}