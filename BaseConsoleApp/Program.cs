using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace BaseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            IServiceCollection serviceCollection = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(serviceCollection);
            //Can add extra services here if needed 
            IServiceProvider provider = serviceCollection.BuildServiceProvider();

            //logging in void main
            var logger = provider.GetService<ILogger<Program>>();
            logger.LogInformation($"Application Started");
            
            IService1 service1 = provider.GetService<IService1>();
            service1.ExampleLogging("");

            


            IDependentService dependentService = provider.GetService<IDependentService>();
            dependentService.RunService1ExampleLogging("This is logged from dependent Service");
        }
    }
}
