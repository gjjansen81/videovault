using Newtonsoft.Json.Linq;

namespace VideoVault.Domain;

public interface IMappingSource
{
    dynamic GetValue(ICoordinate coordinate, bool errorWhenNoMatch);
}