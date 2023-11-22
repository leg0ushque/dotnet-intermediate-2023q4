using Common;
using Kafka.Options;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kafka.Consumer
{
    public class KafkaConsumer : IKafkaConsumer
    {
        private readonly ILogger _logger;
        private readonly IOptions<KafkaOptions> _kafkaOptions;
        private readonly IConsumerProvider _consumerProvider;
        private readonly IProcessingService _processingService;

        public KafkaConsumer(IOptions<KafkaOptions> kafkaOptions,
                             IConsumerProvider consumerProvider,
                             ILogger logger,
                             IProcessingService processingService)
        {
            _kafkaOptions = kafkaOptions;
            _consumerProvider = consumerProvider;
            _logger = logger;
            _processingService = processingService;
        }

        public Task Listen()
        {
            using var consumer = _consumerProvider.Consumer;
            consumer.Subscribe(_kafkaOptions.Value.Topic);

            while (true)
            {
                try
                {
                    var consumeResult = consumer.Consume();
                    var result = new Common.Models.Message(consumeResult.Message.Key, consumeResult.Message.Value);

                    _logger.Information($"Consumed message with key {consumeResult.Message.Key}");

                    _processingService.AddMessage(result);
                }
                catch (Exception e)
                {
                    _logger.Error(e, e.Message);
                }
            }
        }
    }
}
