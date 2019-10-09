using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseConsoleApp
{
    public class AppHost : IAppHost
    {
        private readonly ILogger<AppHost> _logger;
        private readonly IService1 _service1;
        public AppHost(ILoggerFactory loggerFactory, IService1 service1)
        {
            _logger = loggerFactory.CreateLogger<AppHost>(); ;
            _service1 = service1;
        }

        public void DoSomeWork()
        {
            //Run program structure from here. 
            _logger.LogInformation("Doing Work");
            _service1.ExampleLogging("Starting Service 1");
        }
    }

    public interface IAppHost
    {
        public void DoSomeWork();
    }
}
