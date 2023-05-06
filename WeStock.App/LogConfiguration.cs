using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.Text;

namespace WeStock.App
{
    public class LogConfiguration
    {
        public static void Configure()
        {
            var headerSeparator = new string('=', 150);
            var layout = new PatternLayout("%newline ::::: [%thread] :%date{HH:mm:sss} ::::: --%level--%logger::%stacktrace{2}%newline ::::: %message%newline")
            {
                Header = $"\n\n{headerSeparator}\nWeStock [{DateTime.Now}]",
            };

            layout.ActivateOptions();

            var roller = new RollingFileAppender
            {
                Layout = layout,
                AppendToFile = true,
                DatePattern = $"_yyyy\\\\MM\\\\dd'_WeStock.log'",
                RollingStyle = RollingFileAppender.RollingMode.Date,
                MaxSizeRollBackups = 20,
                MaximumFileSize = "10MB",
                StaticLogFileName = false,
                File = GetLogPathBy(),
                Encoding = Encoding.UTF8
            };

            roller.ActivateOptions();

            var hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.AddAppender(roller);
            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
        }

        public static string GetLogPathBy()
        {
            return $"{AppDomain.CurrentDomain.BaseDirectory}\\logs";
        }
    }
}
