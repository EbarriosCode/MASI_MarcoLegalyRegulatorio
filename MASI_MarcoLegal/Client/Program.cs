using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MASI_MarcoLegal.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace MASI_MarcoLegal.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<JWTAuthenticationProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthenticationProvider>(provider => provider.GetRequiredService<JWTAuthenticationProvider>());
            builder.Services.AddScoped<ILoginService, JWTAuthenticationProvider>(provider => provider.GetRequiredService<JWTAuthenticationProvider>());

            await builder.Build().RunAsync();
        }
    }
}
