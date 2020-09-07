using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using MASI_MarcoLegal.Client.Auth;

namespace MASI_MarcoLegal.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Local", options.ProviderOptions);
                options.UserOptions.RoleClaim = "role";
            });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<JWTAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthStateProvider>(provider => provider.GetRequiredService<JWTAuthStateProvider>());
            builder.Services.AddScoped<ILoginService, JWTAuthStateProvider>(provider => provider.GetRequiredService<JWTAuthStateProvider>());

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
