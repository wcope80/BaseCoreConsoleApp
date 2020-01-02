using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;


namespace BaseConsoleApp
{
    public class Service1 : IService1
    {
        private readonly ILogger<Service1> _logger;
        private readonly IConfigurationRoot _config;
        private readonly Guid _ID;
        public Service1(ILoggerFactory loggerFactory, IConfigurationRoot config)
        {
            _logger = loggerFactory.CreateLogger<Service1>();
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
