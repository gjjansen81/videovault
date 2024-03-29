using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Localization;
using VideoVault.WebApi;
using VideoVault.WebUI.Areas.Identity;
using VideoVault.WebUI.ClientApp;
using VideoVault.WebUI.Services;

namespace VideoVault.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddRazorPages().AddNewtonsoftJson();
            services.AddAuthenticationCore();
            //services.AddBlazoredSessionStorage();

            services.AddTransient<AuthorizationHeaderHandler>();
            //services.AddHttpContextAccessor();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITreeCacheService, TreeCacheService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddScoped<IStringLocalizer<App>, StringLocalizer<App>>();

            services.AddHttpClient<IWeatherForecastClient, WeatherForecastClient>(client => client.BaseAddress = new Uri(Configuration.GetSection("VideoVaultApi").Value))
                .AddHttpMessageHandler<AuthorizationHeaderHandler>(); // This handler is on the inside, closest to the request.
            
            services.AddWebClients(Configuration.GetSection("VideoVaultApi").Value, 
                client =>
                {
                    client.BaseAddress = new Uri(Configuration.GetSection("VideoVaultApi").Value);
                });
            //   services.AddHttpClient<IIdentityClient, IdentityClient>(client =>
            //     client.BaseAddress = new Uri(Configuration.GetSection("VideoVaultApi").Value));
            //services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
