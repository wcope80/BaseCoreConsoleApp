
using BaseConsoleApp.Log4Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BaseConsoleApp.Services;

namespace BaseConsoleApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.AddDebug();
                logging.AddLog4Net();
            });
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddTransient<IInjectedService, InjectedService>();
            services.AddScoped<INestedService, NestedService>();
            services.AddScoped<IAppHost, AppHost>();

            services.BuildServiceProvider();
        }


    }
}
