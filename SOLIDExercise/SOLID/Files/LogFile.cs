using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOLID.Files
{
    public class LogFile : IFile
    {
        private StringBuilder sb;
        public LogFile()
        {
            sb = new StringBuilder();
        }
        public string FilePath { get => @"C:\Users\Borislav-PC\source\repos\SOLIDExercise\SOLID\Output\log.txt"; }

        public int Size
            => sb.ToString()
            .Where(c => char.IsLetter(c))
            .Sum(c => c);
        

        public void Write(string message)
        {
            sb.Append(message);
        }
    }
}
