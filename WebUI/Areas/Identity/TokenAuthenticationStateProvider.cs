using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace VideoVault.WebUI.Areas.Identity
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private string _token;

        public void SetToken(string token)
        {
            _token = token;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
            
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = string.IsNullOrWhiteSpace(_token) ? new ClaimsIdentity() : new ClaimsIdentity(ParseClaimsFromJwt(_token), "jwt");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue("role", out var roles);

            if (roles != null)
            {
               if (roles.ToString().Trim().StartsWith("["))
               {
                   var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                   foreach (var parsedRole in parsedRoles)
                   {
                       claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                   }
               }
               else
               {
                   claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
               }

               keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
