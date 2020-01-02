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
        private readonly IDependentService _dependentService;
        public AppHost(ILoggerFactory loggerFactory, IService1 service1, IDependentService dependentService)
        {
            _logger = loggerFactory.CreateLogger<AppHost>();
            _service1 = service1;
            _dependentService = dependentService;
        }

        public void DoSomeWork()
        {
            //Run program structure from here. 
            _logger.LogInformation("Doing Work");
            _service1.ExampleLogging("Starting Service 1");
            _dependentService.RunService1ExampleLogging("Logging from Dependent Service");
        }
    }

    public interface IAppHost
    {
        public void DoSomeWork();
    }
}
