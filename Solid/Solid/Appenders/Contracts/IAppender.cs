using Solid.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Appenders.Contracts
{
    public interface Appender
    {
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
