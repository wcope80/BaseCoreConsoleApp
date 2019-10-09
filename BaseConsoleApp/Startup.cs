
using BaseConsoleApp.Log4Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            services.AddTransient<IService1, Service1>();
            services.AddScoped<IDependentService, DependentService>();
            services.AddScoped<IAppHost, AppHost>();

            services.BuildServiceProvider();
        }


    }
}
