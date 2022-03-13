using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVault.Domain;

namespace Domain.Test.Models
{
    internal class TestMappingSource : IMappingSource
    {
        public dynamic GetValue(ICoordinate coordinate, bool errorWhenNoMatch)
        {
            throw new NotImplementedException();
        }
    }
}
