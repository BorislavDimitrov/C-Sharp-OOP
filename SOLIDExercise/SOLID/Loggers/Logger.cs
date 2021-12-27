using SOLID.Appenders;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using SOLID.ReportLevels;
using System.Linq;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();
            this.appenders = appenders.ToList();
        }
        public IReadOnlyCollection<IAppender> Appender { get => appenders;}

        public void Critical(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Info, message);
        }

        public string Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (var appender in appenders)
            {
                sb.AppendLine(appender.Info());
            }
            return sb.ToString().TrimEnd();
        }

        public void Warning(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Warning, message);
        }

        private void Log(string dateTime, ReportLevel logLevel, string message)
        {
            foreach (var appender in appenders)
            {
                if (appender.ReportLevel <= logLevel )
                {
                    appender.Append(dateTime, logLevel, message);
                }            }
        }
    }
}
