using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using VideoVault.WebUI.Services;

namespace VideoVault.WebUI.Areas.Identity
{
    public class AuthorizationHeaderHandler : DelegatingHandler
    {
        private readonly IIdentityService _identityService;

        public AuthorizationHeaderHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _identityService.GetToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}