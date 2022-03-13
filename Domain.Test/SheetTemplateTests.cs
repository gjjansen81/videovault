using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Microsoft.Extensions.Logging;
using VideoVault.Domain;
using VideoVault.Domain.DataSource;
using VideoVault.Domain.Mapper;
using VideoVault.Domain.Templates;

namespace Domain.Test
{
    [TestClass]
    public class SheetTemplateTests
    {
        [TestMethod]
        public void TestGetValues()
        {
            var inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Files\\TestData.xlsx");
            var resultFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Files\\TestOutput.xlsx");
            var mappingSource = new ExcelMappingSource(inputFilePath);

            var guid = Guid.NewGuid();

            var template = new Template
            {
                Sheets = new List<ISheetTemplate>()
                {
                    new SheetTemplate()
                    {
                        Name = "BladTest1",
                        Rows = new List<IRowTemplate>()
                        {
                            new RowTemplate()
                            {
                                Index = 0,
                                Cells = new List<ICellTemplate>()
                                {
                                    new CellTemplate()
                                    {
                                        Index = 0,
                                        DataSourceGuid = guid
                                    }
                                }
                            },
                            new RowTemplate()
                            {
                                Index = 1,
                                Cells = new List<ICellTemplate>()
                                {
                                    new CellTemplate()
                                    {
                                        Index = 1,
                                        DataSourceGuid = guid
                                    }
                                }
                            }
                        }
                    }
                },
                DataSources = new List<IDataSource>()
                {
                    new DataSource()
                    {
                        Guid = guid,
                        Mapper = new RootNode()
                        {
                            Children = new List<MappingNode>()
                            {
                                new GetValueNode()
                                {
                                    Value = "TestValue1"
                                }
                            }
                        }
                    }
                }
            };

            var mappingData = new MappingData()
            {
                Log = new Logger<SheetTemplateTests>(new LoggerFactory())
            };
            var writer = new ExcelWriter();

            template.Export(mappingData, writer);
            writer.WriteToFile(resultFilePath);
        }
    }
}