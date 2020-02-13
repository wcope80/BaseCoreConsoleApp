using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;


namespace BaseConsoleApp.Services
{
    public class NestedService : INestedService
    {
        private readonly ILogger<NestedService> _logger;
        private readonly IConfigurationRoot _config;
        private readonly Guid _ID;
        public NestedService(ILoggerFactory loggerFactory, IConfigurationRoot config)
        {
            _logger = loggerFactory.CreateLogger<NestedService>();
            _config = config;
            _ID = Guid.NewGuid();
        }

        public void ExampleLogging(string message = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
                _logger.LogInformation(message);
            var setting = _config["Setting1"];
            _logger.LogInformation($"Setting 1 = { setting }");
            _logger.LogInformation($"Instance GUID: { _ID }");            

        }
    }

    public interface IService1
    {
        public void ExampleLogging(string message);
    }
 
}
