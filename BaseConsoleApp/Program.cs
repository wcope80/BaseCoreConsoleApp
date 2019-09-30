using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            Service1 service1 = provider.GetService<Service1>();
            service1.Example();
        }
    }
}
