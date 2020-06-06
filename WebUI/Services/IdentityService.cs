using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VideoVault.WebApi;
using VideoVault.WebUI.Areas.Identity;

namespace VideoVault.WebUI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IIdentityClient _identityClient;
        private readonly TokenAuthenticationStateProvider _tokenAuthenticationStateProvider;
        
        public string TokenKey => "_authToken";

        public IdentityService(IIdentityClient identityClient, AuthenticationStateProvider tokenAuthenticationStateProvider, IMemoryCache memoryCache)
        {
            _identityClient = identityClient;
            _memoryCache = memoryCache;
            _tokenAuthenticationStateProvider = (TokenAuthenticationStateProvider) tokenAuthenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(string userName, string password)
        {
            var result = await _identityClient.AuthenticateAsync(userName, password);

            if (result.Succeeded)
            {
                await _tokenAuthenticationStateProvider.SetTokenAsync(result.Output.Token);
                _memoryCache.Set(TokenKey, result.Output.Token, result.Output.ExpirationDate);
            }
            return result.Succeeded;
        }

        public string GetToken()
        {
            if (_memoryCache.TryGetValue(TokenKey, out string token))
                return token;
            return null;
        }
    }
}
