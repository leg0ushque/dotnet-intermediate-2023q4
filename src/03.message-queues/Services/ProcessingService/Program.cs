using Common;
using Common.DependencyInjection;
using Kafka;
using Kafka.Consumer;
using Kafka.Options;
using Kafka.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ProcessingService
{
    public class Program : SettingsBaseProgram
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();
            Console.WriteLine("Processing Service started listening.");

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
                services.AddTransient<IProcessingService, ProcessingService>();
                services.AddTransient<IConsumerProvider, KafkaConsumerProvider>();
                services.AddTransient<IKafkaConsumer, KafkaConsumer>();


                services.AddHostedService<ProcessingHostedService>();
            });

            return hostBuilder;
        }
    }
}