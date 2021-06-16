using Solid.Enums;
using Solid.Layouts;
using Solid.Loggers;
using System;
using System.IO;

namespace Solid.Appenders
{
    public class FileAppender : Appender
    {

        private ILayout layout;
        private IlogFile logFile;
        public FileAppender(ILayout layout, IlogFile logFile) 
            : base(layout)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date, reportLevel, message) + Environment.NewLine;
            this.logFile.Write(content);
        }
    }
}
