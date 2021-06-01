using Blazored.LocalStorage;
using LXProtocols.AvolitesWebAPI.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LXTouch
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<LXLayoutService>();
            builder.Services.AddAvolitesTitan();
            builder.Services.AddBlazoredLocalStorage();

            var host = builder.Build();

            //Initialise the Layout
            var visitorManager = host.Services.GetRequiredService<LXLayoutService>();
            await visitorManager.InitialiseAsync();

            await host.RunAsync();
        }
    }
}
