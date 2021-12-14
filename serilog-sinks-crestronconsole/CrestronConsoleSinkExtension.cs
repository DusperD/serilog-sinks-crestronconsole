using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using System;

namespace serilog_sinks_crestronconsole
{
    /// <summary>
    /// Adds the WriteTo.CrestronConsoleSink() extension method 
    /// </summary>
    public static class CrestronConsoleSinkExtension
    {
        const string DefaultDebugOutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";
        /// <summary>
        /// Writes log events to <see cref="CrestronConsole"/>.
        /// </summary>
        /// <param name="loggerConfiguration">Logger sink configuration.</param>
        /// <param name="restrictedToMinimumLevel">The minimum level forevents passed through the sink. Ignored when <paramref name="levelSwitch"/> is specified.</param>
        /// <param name="levelSwitch">A switch allowing the pass-through minimum level to be changed at runtime.</param>
        /// <param name="outputTemplate">A message template describing the format used to write to the sink.the default is <code>"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"</code>.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration CrestronConsoleSink(
              this LoggerSinkConfiguration loggerConfiguration,
              LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
              string outputTemplate = DefaultDebugOutputTemplate,
              IFormatProvider formatProvider = null,
              LoggingLevelSwitch levelSwitch = null)
        {

            if (loggerConfiguration == null) throw new ArgumentNullException(nameof(loggerConfiguration));
            if (outputTemplate == null) throw new ArgumentNullException(nameof(outputTemplate));

            var formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);
            return loggerConfiguration.Sink(new CrestronConsoleSink(formatter));
        }
    }
}
