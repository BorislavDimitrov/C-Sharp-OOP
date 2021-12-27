using SOLID.Layouts;
using System;
using SOLID.ReportLevels;
using System.Text;

namespace SOLID.Appenders
{
    public class ConsoleAppender : Appender
    {
        private int messagesAppended;
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override int MessagesAppended
            => messagesAppended;

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            string appendMessage = string.Format(Layout.Format, dateTime, reportLevel, message);
            messagesAppended++;
            Console.WriteLine(appendMessage);
        }

        public override string Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}" +
                    $", Report level: {ReportLevel}, Messages appended: {MessagesAppended}");
            return sb.ToString().TrimEnd();
        }
    }
}
