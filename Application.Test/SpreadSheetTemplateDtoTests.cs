using AutoMapper;
using VideoVault.Application.Common.Mappings;
using VideoVault.Application.Common.Models;
using VideoVault.Domain.Entities;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Domain.Test
{
    [TestClass]
    public class SpreadSheetTemplateDtoTests
    {
        [TestMethod]
        public void TestMapping()
        {
            var guid = Guid.NewGuid();

            var templateDto = new SpreadSheetTemplateDto
            {
                Sheets = new List<SheetTemplateDto>()
                {
                    new SheetTemplateDto()
                    {
                        Name = "BladTest1",
                        Rows = new List<RowTemplateDto>()
                        {
                            new RowTemplateDto()
                            {
                                Index = 0,
                                Cells = new List<CellTemplateDto>()
                                {
                                    new CellTemplateDto()
                                    {
                                        Index = 0,
                                        DataSourceGuid = guid
                                    }
                                }
                            },
                            new RowTemplateDto()
                            {
                                Index = 1,
                                Cells = new List<CellTemplateDto>()
                                {
                                    new CellTemplateDto()
                                    {
                                        Index = 1,
                                        DataSourceGuid = guid
                                    }
                                }
                            }
                        }
                    }
                },
                DataSources = new List<DataSourceDto>()
                {
                    new DataSourceDto()
                    {
                        Guid = guid,
                        RootNode = new MappingNodeDto()
                        {
                            Children = new List<MappingNodeDto>()
                            {
                                new MappingNodeDto()
                                {
                                    Name = "TestValue1"
                                }
                            }
                        }
                    }
                }
            };
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    new MappingProfile()
                );
            var mapper = new Mapper(config);

            var template = mapper.Map<Template>(templateDto);
        }
    }
}