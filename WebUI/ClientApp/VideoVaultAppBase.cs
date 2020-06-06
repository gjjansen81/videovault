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
            var msg = new HttpRequestMessage();

            //var identityService = HttpContext.RequestServices.GetService<IIdentityService>();
            //var token = await IdentityService.GetToken());

          //  if (identityService!= null)
            {
                var token = "";//await identityService();
                msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return msg;
        }

    }
}
