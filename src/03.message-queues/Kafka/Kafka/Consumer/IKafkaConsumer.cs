using System.Threading.Tasks;

namespace Kafka.Consumer
{
    public interface IKafkaConsumer
    {
        public Task Listen();
    }
}