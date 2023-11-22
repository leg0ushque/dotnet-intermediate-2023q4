using common.messageQueuesTask;
using Confluent.Kafka;
using System;

namespace Kafka.Producer
{
    public interface IProducerProvider : IDisposable
    {
        IProducer<string, MessageValue> Producer { get; }
    }
}
