using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace BaseConsoleApp.Log4Net
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }

        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
        {
            factory.AddProvider(new Log4NetProvider("log4net.config"));
            return factory;
        }
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, bool skipDiagnosticLogs)
        {
            factory.AddProvider(new Log4NetProvider("log4net.config", skipDiagnosticLogs));
            return factory;
        }

        public static ILoggingBuilder AddLog4Net(this ILoggingBuilder builder)
        {
            builder.AddProvider(new Log4NetProvider("log4net.config"));
            return builder;
        }
    }
}
