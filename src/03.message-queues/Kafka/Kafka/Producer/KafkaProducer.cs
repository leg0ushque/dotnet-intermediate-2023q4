using common.messageQueuesTask;
using Common.Models;
using Kafka.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kafka.Producer
{
    public class KafkaProducer : IKafkaProducer
    {
        private static ILogger _logger;
        private readonly IProducerProvider _producerProvider;
        private readonly IOptions<KafkaOptions> _kafkaOptions;

        public KafkaProducer(IProducerProvider producerProvider,
                             IOptions<KafkaOptions> kafkaOptions,
                             ILogger logger)
        {
            _kafkaOptions = kafkaOptions;
            _logger = logger;
            _producerProvider = producerProvider;
        }

        public async Task ProduceMessageAsync(Message message)
        {
            try
            {
                var producer = _producerProvider.Producer;

                var confluentKafkaMessage = new Confluent.Kafka.Message<string, MessageValue>
                {
                    Key = message.Key,
                    Value = message.Value
                };

                _logger.Information("Trying to produce a message");
                _logger.Information(JsonConvert.SerializeObject(confluentKafkaMessage));

                await producer.ProduceAsync(_kafkaOptions.Value.Topic, confluentKafkaMessage);

                producer.Flush();
            }

            catch (Exception e)
            {
                _logger.Error(e.ToString());
                _logger.Error($"Position:{message.Value.Position}, Content Size: {message.Value.Content.Length}");
            }

        }
    }
}
