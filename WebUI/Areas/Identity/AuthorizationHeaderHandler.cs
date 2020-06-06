using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using VideoVault.WebUI.Areas.Identity;
using VideoVault.WebUI.Services;

namespace VideoVault.WebUI
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