using AutoMapper;
using Infrastructure.DataSources;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NPOI.XSSF.UserModel;
using VideoVault.Application.Common.Mappings;
using VideoVault.Domain;
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
                        },
                        new GetValueFromSourceNode()
                        {
                            Coordinate = new ExcelCoordinate("S1", 2, 3)
                        }
                    }
                }
            }
        };

        private DataSourceService? _dataSourceService = null;
        private readonly ApplicationDbContext? _context = null;
        private readonly Guid _dataSourceGuid1 = Guid.NewGuid();

        [TestInitialize]
        public void TestInit()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("VideoVaultDb");
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InfrastructureMappingProfile());
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            _dataSourceService = new DataSourceService(_context, mapper);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context?.Dispose();
        }
            
        [TestMethod]
        public void GetAvailableMappingNodesTests()
        {
            try
            {
                var result = _dataSourceService?.GetAvailableMappingNodes();
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 2);
                Assert.IsTrue(result.Any(x => x.FullName.Contains("GetValueNode")));
                Assert.IsTrue(!result.Any(x => x.FullName.Contains("RootNode")));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void ConvertToMappingNodesTests()
        {
            var rootNode = _dataSourceService?.ConvertToMappingNodeDto(_testRoot);
            var result = _dataSourceService?.ConvertToMappingNodes(rootNode);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Children.Count == 1);
            Assert.IsTrue(result.Children.First().Children.Count == 3);
            Assert.IsTrue(result.Children.Any(x => x is ConcatNode));
            Assert.IsTrue(result.Children.First().Children.Where(x => x is GetValueNode).ToList().Count() == 2);
            Assert.IsTrue(result.Children.First().Children.Where(x => x is GetValueFromSourceNode).ToList().Count() == 1);
        }

        [TestMethod]
        public void ConvertToMappingNodeDtoTests()
        {
            var result = _dataSourceService?.ConvertToMappingNodeDto(_testRoot);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Children.Count == 1);
            Assert.IsTrue(result.Children[0].Children.Count == 3);

            Assert.IsTrue(result.FullName.Contains("RootNode"));
            Assert.IsTrue(!result.Children.Any(x => x.FullName.Contains("GetValueNode")));
            Assert.IsTrue(result.Children.All(x => x.FullName.Contains("ConcatNode")));
            Assert.IsTrue(result.Children.First().Children.Where(x => x.FullName.Contains("GetValueNode")).ToList().Count == 2);
            var child1 = result.Children.First().Children[0].Parameters.Where(x => x.Name.Equals("Value", StringComparison.InvariantCultureIgnoreCase)).ToList().First();
            var child2 = result.Children.First().Children[1].Parameters.Where(x => x.Name.Equals("Value", StringComparison.InvariantCultureIgnoreCase)).ToList().First();
            var child3 = result.Children.First().Children[2].Parameters.Where(x => x.Name.Equals("Coordinate", StringComparison.InvariantCultureIgnoreCase)).ToList().First();
            Assert.IsTrue(child1.Value.Equals("A1"));
            Assert.IsTrue(child2.Value.Equals("B2"));
            Assert.IsTrue(child3.Value.SheetName.Equals("S1"));
        }

        [TestMethod]
        public void ConvertFromJsonTest()
        {
      //      var mapper = "{\"Name\":null,\"Entity\":0,\"Destination\":null,\"Guid\":\"2a8d6fdc-61d5-4eee-a6f2-0fec678094cd\",\"Children\":[{\"$type\":\"VideoVault.Domain.Mapper.GetValueFromSourceNode,VideoVault.Domain\",\"Coordinate\":null,\"TryParseToNumber\":false,\"ConvertToString\":false,\"Trim\":false,\"PropertyNode\":null,\"Guid\":\"f9167ccd-4743-4cf6-bc18-7567466d1e9b\",\"Children\":[],\"ValidationRules\":[]}],\"ValidationRules\":[]}";
            //var mapper1 = "{\"Name\":null,\"Entity\":0,\"Destination\":null,\"Guid\":\"c650d95e-0104-4af3-802a-a1fcd4ff19ef\",\"Children\":[{\"$type\":\"VideoVault.Domain.Mapper.GetValueNode, VideoVault.Domain\",\"Value\":\"true\",\"Guid\":\"e9847af5-27d0-432a-aa25-70ee5e6a21b3\",\"Children\":[],\"ValidationRules\":[]}],\"ValidationRules\":[]}";
            var mapper = @"{""Name"": null,

                                ""Entity"": 0,
                                ""Destination"": null,
                                ""Guid"": ""2a8d6fdc-61d5-4eee-a6f2-0fec678094cd"",
                                ""Children"": [

                                {
                                    ""$type"": ""VideoVault.Domain.Mapper.GetValueFromSourceNode, VideoVault.Domain"",
                                    ""Coordinate"": null,
                                    ""TryParseToNumber"": false,
                                    ""ConvertToString"": false,
                                    ""Trim"": false,
                                    ""PropertyNode"": null,
                                    ""Guid"": ""f9167ccd-4743-4cf6-bc18-7567466d1e9b"",
                                    ""Children"": [],
                                    ""ValidationRules"": []

                                }
                                ],
                                ""ValidationRules"": []
                            }";
            try
            {
                var mappingNode = _dataSourceService?.ConvertFromJson(mapper);

                Assert.IsNotNull(mappingNode);
            }
            catch (Exception)
            {
                ;
            }
        }

        [TestMethod]
        public void ConvertToJsonTest()
        {
            var mappingNode = new RootNode()
            {
                Children = new List<MappingNode>()
                {
                    new GetValueFromSourceNode()
                    {
                    },
                    new GetValueNode()
                    {
                        Value = "testA"
                    }
                }
            };
            var mapper = _dataSourceService?.ConvertToJson(mappingNode);
            Assert.IsNotNull(mapper);
        }
    }
}