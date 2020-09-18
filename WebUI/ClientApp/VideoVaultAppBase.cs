using Blazored.SessionStorage;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.WebUI.Services;

namespace VideoVault.WebApi
{
    public abstract class VideoVaultAppBase
    {
        // Called by implementing swagger client classes
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult<HttpRequestMessage>(new HttpRequestMessage());
        }

    }
}
