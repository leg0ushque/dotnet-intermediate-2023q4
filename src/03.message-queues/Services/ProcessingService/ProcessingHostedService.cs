using Kafka.Consumer;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingService
{
    public class ProcessingHostedService : IHostedService
    {
        private readonly IKafkaConsumer _kafkaConsumer;

        public ProcessingHostedService(IKafkaConsumer kafkaConsumer)
        {
            _kafkaConsumer = kafkaConsumer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => _kafkaConsumer.Listen());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
