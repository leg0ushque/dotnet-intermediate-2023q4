using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace Common.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static void ConfigureLogger(this IServiceCollection services)
        {
            var loggerOutputTemplate =
                "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.RollingFile(@"Logs\Info-{Date}.log", outputTemplate: loggerOutputTemplate))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.RollingFile(@"Logs\Warning-{Date}.log", outputTemplate: loggerOutputTemplate))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.RollingFile(@"Logs\Error-{Date}.log", outputTemplate: loggerOutputTemplate))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal).WriteTo.RollingFile(@"Logs\Fatal-{Date}.log", outputTemplate: loggerOutputTemplate))
                .WriteTo.RollingFile(@"Logs\All-{Date}.log", outputTemplate: loggerOutputTemplate)
                .CreateLogger();

            services.AddSingleton<ILogger>(loggerConfiguration);
        }
    }
}