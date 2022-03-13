using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using VideoVault.Domain;

namespace Domain.Test
{
    [TestClass]
    public class ExcelMappingSourceTests
    {
        [TestMethod]
        public void TestGetValues()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Files\\TestData.xlsx");
            var mappingSource = new ExcelMappingSource(filePath);

            var columnValue1 = mappingSource.GetValue(new ExcelCoordinate("Blad1", 1, 2));
            var columnValue2 = mappingSource.GetValue(new ExcelCoordinate("Blad1", 4, 3));
            var columnValue3 = mappingSource.GetValue(new ExcelCoordinate("Blad2", 2, 1));
            
            var columnValue4 = mappingSource.GetValue(new ExcelCoordinate("Blad1", 1, 1));

            Assert.AreEqual(columnValue1, "ColumnB-Row3");
            Assert.AreEqual(columnValue2, "ColumnE-Row4");
            Assert.AreEqual(columnValue3, "ColumnC -Row2");
            Assert.IsNull(columnValue4);
        }
    }
}