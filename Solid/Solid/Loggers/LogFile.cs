using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solid.Loggers
{
    public class LogFile : IlogFile
    {
        private const string FilePath = "./log.txt";

        public int Size { get; }

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
