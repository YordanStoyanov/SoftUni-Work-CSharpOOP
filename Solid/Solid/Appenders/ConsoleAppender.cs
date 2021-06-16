namespace Solid.Appenders
{
    using Solid.Enums;
    using Solid.Layouts;
    public class ConsoleAppender : Appender
    {
        private ILayout layout;
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
            this.layout = layout;
        }
        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date, reportLevel, message);
            System.Console.WriteLine(content);
        }
    }
}
