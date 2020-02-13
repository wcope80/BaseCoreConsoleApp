using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using BaseConsoleApp.Services;
namespace BaseConsoleApp
{
    public class AppHost : IAppHost
    {
        private readonly ILogger<AppHost> _logger;
        private readonly IInjectedService _injectedService;
        private readonly INestedService _nestedService;
        public AppHost(ILoggerFactory loggerFactory,  IInjectedService injectedService,INestedService nestedService)
        {
            _logger = loggerFactory.CreateLogger<AppHost>();
            _injectedService = injectedService;
            _nestedService = nestedService;
        }

        public void DoSomeWork()
        {
            //Run program structure from here. 
            _logger.LogInformation("Doing Work");
            _injectedService.ExampleLogging("Starting Injected Service");
            _nestedService.ExampleLogging("Logging from Nested Service");
        }
    }

    public interface IAppHost
    {
        public void DoSomeWork();
    }
}
