using Microsoft.Extensions.DependencyInjection;
using System;
using VideoVault.WebApi;

namespace VideoVault.WebUI.ClientApp
{
    public static class ClientFactory
    {
        public static IServiceCollection AddWebClients(this IServiceCollection services, string baseUrl, Action<System.Net.Http.HttpClient> configureClient)
        {
            services.AddHttpClient<ICustomerClient, CustomerClient>(client => client.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IIdentityClient, IdentityClient>(client => client.BaseAddress = new Uri(baseUrl));
            return services;

        }
    }
}
