using Common.Models;

namespace Common
{
    public interface IProcessingService
    {
        public void AddMessage(Message message);

        public void SaveToLocalFolder(string key);
    }
}
