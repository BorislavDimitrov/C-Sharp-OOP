using System;
using SOLID.Layouts;
using SOLID.Appenders;
using SOLID.Loggers;
using SOLID.Files;
using SOLID.ReportLevels;
using System.Collections.Generic;
using System.Linq;
using SOLID.Factory;

namespace SOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            List<IAppender> appenders = new List<IAppender>();
            int appendersNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendersNum; i++)
            {
                List<string> appendInput = Console.ReadLine().Split().ToList();
                string appendType = appendInput[0];
                string layoutType = appendInput[1];
              //  ILayout newLayout = null;
                IAppender newAppender = null;

                // if (layoutType == "SimpleLayout")
                // {
                //     newLayout = new SimpleLayout();
                // }
                // else if (layoutType == "XmlLayout")
                // {
                //     newLayout = new XmlLayout();
                // }

                ILayout newLayout = layoutFactory.Create(layoutType);
                if (appendType == "ConsoleAppender")
                {
                    newAppender = new ConsoleAppender(newLayout);
                }
                else if (appendType == "FileAppender")
                {
                    IFile newFile = new LogFile();
                    newAppender = new FileAppender(newLayout, newFile);
                }

                if (appendInput.Count == 3)
                {
                    string reportLevel = appendInput[2].ToLower();
                    bool isValidReportLevel = Enum.TryParse(reportLevel, true, out ReportLevel repLevel);

                    if (isValidReportLevel)
                    {
                        newAppender.ReportLevel = repLevel;
                    }
                }

                appenders.Add(newAppender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                List<string> messageInfo = input.Split("|" , StringSplitOptions.RemoveEmptyEntries).ToList();
                string reportLevel = messageInfo[0].ToLower();
                string dateTime = messageInfo[1];
                string message = messageInfo[2];

                if (reportLevel == "info")
                {
                    logger.Info(dateTime, message);
                }
                else if (reportLevel == "warning")
                {
                    logger.Warning(dateTime, message);
                }
                else if (reportLevel == "error")
                {
                    logger.Error(dateTime, message);
                }
                else if (reportLevel == "critical")
                {
                    logger.Critical(dateTime, message);
                }
                else if (reportLevel == "fatal")
                {
                    logger.Fatal(dateTime, message);
                }
            }

            Console.WriteLine(logger.Info());
        }
    }
}
