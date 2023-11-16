using Confluent.SchemaRegistry;
using System;

namespace Kafka.Schema
{
    public interface IKafkaSchemaProvider : IDisposable
    {
        CachedSchemaRegistryClient SchemaConfig { get; }
    }
}
