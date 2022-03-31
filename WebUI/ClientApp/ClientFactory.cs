using Microsoft.Extensions.DependencyInjection;
using System;
using VideoVault.WebApi;
using VideoVault.WebUI.Areas.Identity;

namespace VideoVault.WebUI.ClientApp
{
    public static class ClientFactory
    {
        public static IServiceCollection AddWebClients(this IServiceCollection services, string baseUrl, Action<System.Net.Http.HttpClient> configureClient)
        {
            services.AddHttpClient<IIdentityClient, IdentityClient>(client => client.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<ICustomerClient, CustomerClient>(client => client.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler<AuthorizationHeaderHandler>(); // This handler is on the inside, closest to the request.
            services.AddHttpClient<ITemplateClient, TemplateClient>(client => client.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler<AuthorizationHeaderHandler>(); // This handler is on the inside, closest to the request.
            services.AddHttpClient<IUserClient, UserClient>(client => client.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler<AuthorizationHeaderHandler>(); // This handler is on the inside, closest to the request.
            services.AddHttpClient<IDataSourceClient, DataSourceClient>(client => client.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler<AuthorizationHeaderHandler>(); // This handler is on the inside, closest to the request.
            return services;

        }
    }
}
