using Common;
using Common.DependencyInjection;
using DataCapturingService;
using Kafka;
using Kafka.Options;
using Kafka.Producer;
using Kafka.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DataCaptureService
{
    public class Program : SettingsBaseProgram
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();
            Console.WriteLine($"File Folder Monitoring started monitoring {Constants.FolderBasePath}{Constants.MonitoredFolderName}");

            app.Run();

            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureServices(services =>
            {
                SetupSettingsJson();

                services.AddOptions<KafkaOptions>()
                    .Bind(_configuration.GetSection(KafkaOptions.ConfigurationSection));

                services.ConfigureLogger();

                services.AddTransient<KafkaConfigurationProvider>();
                services.AddTransient<IKafkaSchemaProvider, KafkaSchemaProvider>();
                services.AddTransient<IProducerProvider, KafkaProducerProvider>();
                services.AddTransient<IKafkaProducer, KafkaProducer>();

                services.AddTransient<IFileFolderMonitoringService, FileFolderMonitoringService>();

                services.AddHostedService<DataCaptureHostedService>();
            });

            return hostBuilder;
        }
    }
}