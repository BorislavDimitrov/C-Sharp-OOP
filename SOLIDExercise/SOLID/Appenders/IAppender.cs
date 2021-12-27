using System;
using System.Collections.Generic;
using System.Text;
using SOLID.ReportLevels;
using SOLID.Layouts;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get;}

        void Append(string dateTime, ReportLevel reportLevel, string message);

        public int MessagesAppended { get;}

        public ReportLevel ReportLevel { get; set; }

        public string Info();
    }
}
