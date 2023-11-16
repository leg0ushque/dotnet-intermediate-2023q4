using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;

namespace Kafka.Producer
{
    public class NewtonsoftSerializer<T> : ISerializer<T>
        where T : class
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (data == null)
            {
                return null;
            }

            var jsonString = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(jsonString);
        }
    }
}
