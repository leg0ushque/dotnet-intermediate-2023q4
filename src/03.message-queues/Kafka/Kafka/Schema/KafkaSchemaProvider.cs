using Confluent.SchemaRegistry;
using Kafka.Options;
using Microsoft.Extensions.Options;

namespace Kafka.Schema
{
    public class KafkaSchemaProvider : IKafkaSchemaProvider
    {
        public CachedSchemaRegistryClient SchemaConfig { get; }

        private bool _disposed;

        public KafkaSchemaProvider(IOptions<KafkaOptions> kafkaOptions)
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = kafkaOptions.Value.SchemaServer,
                BasicAuthCredentialsSource = AuthCredentialsSource.UserInfo,
                BasicAuthUserInfo = $"{kafkaOptions.Value.SchemaApiKey}:{kafkaOptions.Value.SchemaApiSecret}",
            };
            SchemaConfig = new CachedSchemaRegistryClient(schemaRegistryConfig);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                SchemaConfig.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
