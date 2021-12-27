using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Appenders;

namespace SOLID.Loggers
{
    public interface ILogger
    {
        public IReadOnlyCollection<IAppender> Appender { get;}

        void Info(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Error(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dateTime, string message);

        public string Info();

    }
}
