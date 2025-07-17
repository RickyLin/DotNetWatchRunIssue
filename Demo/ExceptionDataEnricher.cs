using Serilog.Core;
using Serilog.Events;

namespace Demo
{
    public class ExceptionDataEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception == null || logEvent.Exception.Data == null || logEvent.Exception.Data.Count == 0)
                return;

            string exceptionData = $"DemoKey: {logEvent.Exception.Data["DemoKey"]}";
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ExceptionData", exceptionData));
        }
    }
}
