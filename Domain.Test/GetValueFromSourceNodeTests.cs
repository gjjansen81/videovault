using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoVault.Domain;
using VideoVault.Domain.Mapper;

namespace Domain.Test
{
    [TestClass]
    public class GetValueFromSourceNodeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\TestData.xlsx");
            MappingData mappingData = new MappingData()
            {
                Log = new Logger<GetValueFromSourceNodeTests>(new LoggerFactory()),
                Source = new ExcelMappingSource(filePath)
            };
            var mapper = new GetValueFromSourceNode()
            {
                Coordinate = new ExcelCoordinate("Blad1", 1, 2)
            };
            var result = mapper.Resolve(mappingData);
            Assert.AreEqual(result, "ColumnB-Row3");
        }
    }
}