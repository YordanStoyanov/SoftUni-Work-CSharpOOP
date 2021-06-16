using Solid.Appenders.Contracts;
using Solid.Loggers.Contracts;
using Solid;
using Solid.Enums;

namespace Solid.Loggers
{
    public class Logger : ILogger
    {
        private Appender appender;
        private LogFile logFile;

        public Logger(Appender appender)
        {
            this.appender = appender;
        }
        public void Error(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Info, message);
        }
    }
}
