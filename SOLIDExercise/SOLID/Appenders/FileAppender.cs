using SOLID.Layouts;
using System.IO;
using SOLID.ReportLevels;
using SOLID.Files;
using System;
using System.Text;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private int messagesAppended;
        public FileAppender(ILayout layout, IFile fileAppend) 
            : base(layout)
        {
            FileAppend = fileAppend;
        }

        public IFile FileAppend { get;}

        public override int MessagesAppended => messagesAppended;

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            string appendMessage = string.Format(Layout.Format, dateTime, reportLevel, message);

            FileAppend.Write(message);

            messagesAppended++;

            File.AppendAllText(FileAppend.FilePath, appendMessage + Environment.NewLine);
        }

        public override string Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}" +
                    $", Report level: {ReportLevel}, Messages appended: {MessagesAppended}, File size: {FileAppend.Size}");
            return sb.ToString().TrimEnd();
        }
    }
}
