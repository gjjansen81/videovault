using System.Collections.Generic;
using System.IO;
using Domain.Test.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoVault.Domain;
using VideoVault.Domain.Mapper;

namespace Domain.Test
{
    [TestClass]
    public class RootNodeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            MappingData mappingData = new MappingData()
            {
                Log = new Logger<GetValueFromSourceNodeTests>(new LoggerFactory()),
                Source = new TestMappingSource()
            };

            var mapper = new RootNode()
            {
                Children = new List<MappingNode>()
                {
                    new GetValueNode()
                    {
                        Value = "TestValue1"
                    }
                }
            };
            var result = mapper.Resolve(mappingData);
            Assert.IsTrue(result is List<dynamic>);
            Assert.AreEqual(result[0], "TestValue1");
        }
    }
}