using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VideoVault.WebApi//.ClientApp
{
    public abstract class VideoVaultAppBase
    {
        // Called by implementing swagger client classes
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(new HttpRequestMessage());
        }
    }
}
