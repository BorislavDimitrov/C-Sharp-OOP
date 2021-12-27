using SOLID.Layouts;
using SOLID.ReportLevels;

namespace SOLID.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }
        public abstract int MessagesAppended { get;}

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public abstract string Info();
        
    }
}
