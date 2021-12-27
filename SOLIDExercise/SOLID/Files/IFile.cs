using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Files
{
    public interface IFile
    {
        public string FilePath { get;}
        public int Size { get; }
        public void Write(string message);

    }
}
