using common.messageQueuesTask;
using Confluent.Kafka;
using System;

namespace Kafka.Consumer
{
    public interface IConsumerProvider : IDisposable
    {
        IConsumer<string, MessageValue> Consumer { get; }
    }

}
