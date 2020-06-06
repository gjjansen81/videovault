using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VideoVault.WebApi;
using VideoVault.WebUI.Services;

namespace VideoVault.WebUI.ClientApp
{
    public static class ClientFactory
    {
        public static IServiceCollection AddWebClients(this IServiceCollection services, string baseUrl, Action<System.Net.Http.HttpClient> configureClient)
        {
            //services.Resolve()
            //var identityService = new IdentityService();

            //HttpClient httpClient;
            services.AddHttpClient<ICustomerClient, CustomerClient>(client => client.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IIdentityClient, IdentityClient>(client => client.BaseAddress = new Uri(baseUrl));
            return services;

        }
        /*
        public static ICustomerClient CreateCustomerClient(string baseUrl, HttpClient http, Func<Task<string>> retrieveAuthorizationToken)
        {
            return new CustomerClient(baseUrl, http)
            {
                RetrieveAuthorizationToken = retrieveAuthorizationToken
            };
        }*/
    }
}
