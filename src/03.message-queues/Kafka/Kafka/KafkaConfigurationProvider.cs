﻿using Confluent.Kafka;
using Kafka.Options;
using Microsoft.Extensions.Options;

namespace Kafka
{
    public class KafkaConfigurationProvider
    {
        public ConsumerConfig ConsumerConfiguration { get; }

        public ProducerConfig ProducerConfiguration { get; }

        public KafkaConfigurationProvider(IOptions<KafkaOptions> kafkaOptions)
        {
            var kafka = kafkaOptions.Value;

            ConsumerConfiguration = new ConsumerConfig
            {
                BootstrapServers = kafka.BootstrapServer,
                GroupId = kafka.ClientId,
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.Plaintext,
                SslEndpointIdentificationAlgorithm = SslEndpointIdentificationAlgorithm.None,
            };

            ProducerConfiguration = new ProducerConfig
            {
                BootstrapServers = kafka.BootstrapServer,
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.Plaintext,
                SslEndpointIdentificationAlgorithm = SslEndpointIdentificationAlgorithm.None,
            };
        }
    }

}
