using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BaseConsoleApp.Services
{
    public class InjectedService : IInjectedService
    {
        private readonly INestedService _nestedService;
        private readonly ILogger<InjectedService> _logger;
        private readonly IConfigurationRoot _config;

        public InjectedService(INestedService nestedService, ILoggerFactory loggerFactory, IConfigurationRoot config)
        {
            _nestedService = nestedService;
            _logger = loggerFactory.CreateLogger<InjectedService>();
            _config = config;
        }

        public void ExampleLogging(string message)
        {
            
            _nestedService.ExampleLogging(message);
        }

    }

}
