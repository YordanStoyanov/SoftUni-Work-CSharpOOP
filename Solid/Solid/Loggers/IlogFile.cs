using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Loggers
{
    public interface IlogFile
    {
        int Size { get; }
        void Write(string content);
    }
}
