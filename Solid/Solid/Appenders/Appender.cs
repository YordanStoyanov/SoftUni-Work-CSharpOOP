using Solid.Appenders.Contracts;
using Solid.Enums;
using Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Appenders
{
    public abstract class Appender : Contracts.Appender
    {
        private ILayout layout;
        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        
    }
}
