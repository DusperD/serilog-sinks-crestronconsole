using Crestron.SimplSharp;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serilog_sinks_crestronconsole
{

    public class CrestronConsoleSink : ILogEventSink
    {
        private readonly ITextFormatter _formatter;

        public CrestronConsoleSink(ITextFormatter formatter)
        {
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }
        public void Emit(LogEvent logEvent)
        {
            using(var buffer=new System.IO.StringWriter())
            {
                _formatter.Format(logEvent, buffer);
                CrestronConsole.PrintLine(buffer.ToString());
                
            }
        }
    }
}


