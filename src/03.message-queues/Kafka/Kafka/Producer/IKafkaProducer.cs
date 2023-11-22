using Common.Models;
using System.Threading.Tasks;

namespace Kafka.Producer
{
    public interface IKafkaProducer
    {
        public Task ProduceMessageAsync(Message message);
    }
}
