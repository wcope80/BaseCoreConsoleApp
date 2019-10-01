using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BaseConsoleApp
{
    public class DependentService : IDependentService
    {
        private readonly IService1 _service1;
        private readonly ILogger<Service1> _logger;
        private readonly IConfigurationRoot _config;

        public DependentService(IService1 service1, ILoggerFactory loggerFactory, IConfigurationRoot config)
        {
            _service1 = service1;
            _logger = loggerFactory.CreateLogger<Service1>();
            _config = config;
        }

        public void RunService1ExampleLogging(string message)
        {
            _service1.ExampleLogging(message);
        }

    }

    public interface IDependentService
    {
        public void RunService1ExampleLogging(string message);
    }
}
