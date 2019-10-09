using System.IO;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace BaseConsoleApp.Log4Net
{
    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;

        private readonly bool _skipDiagnosticLogs;

        private readonly ConcurrentDictionary<string, ILogger> _loggers =
            new ConcurrentDictionary<string, ILogger>();

        public Log4NetProvider(string log4NetConfigFile, bool skipDiagnosticLogs = false)
        {
            _log4NetConfigFile = log4NetConfigFile;
            _skipDiagnosticLogs = skipDiagnosticLogs;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }

        private ILogger CreateLoggerImplementation(string name)
        {
            var log = new FileInfo(_log4NetConfigFile);
            return new Log4NetLogger(name, new FileInfo(_log4NetConfigFile), _skipDiagnosticLogs);
        }
    }
}
