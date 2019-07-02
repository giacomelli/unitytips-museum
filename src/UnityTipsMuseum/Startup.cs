using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using UnityTipsMuseum.Infrastructure;
using UnityTipsMuseum.Services;

namespace UnityTipsMuseum
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLoadingBar(); 
            services.AddSingleton<TipService>();
            services.AddSingleton<LogService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
            app.UseLoadingBar();
        }
    }
}
