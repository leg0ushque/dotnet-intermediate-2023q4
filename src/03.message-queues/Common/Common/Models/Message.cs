using common.messageQueuesTask;

namespace Common.Models
{
    public class Message
    {
        public string Key { get; set; }
        public MessageValue Value { get; set; }

        public Message(string key, MessageValue value)
        {
            Key = key;
            Value = value;
        }
    }

}
