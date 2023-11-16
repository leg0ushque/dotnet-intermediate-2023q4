using Common;
using Common.Models;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProcessingService
{
    public class ProcessingService : IProcessingService
    {
        public static List<MessagePartialContent> MessageParts = new List<MessagePartialContent>();
        private static ILogger _logger;

        public ProcessingService(ILogger logger)
        {
            _logger = logger;
        }

        public void AddMessage(Message message)
        {
            MessageParts.Add(new MessagePartialContent(message.Key, message.Value.Content, message.Value.ChunkSize, message.Value.Position));

            if (message.Value.ChunkSize - 1 == message.Value.Position)
            {
                SaveToLocalFolder(message.Key);
            }
        }

        public void SaveToLocalFolder(string key)
        {
            var fullContent = new List<byte>();
            var documents = MessageParts.Where(d => d.FileName == key).OrderBy(d => d.Position).ToList();

            for (int i = 0; i < documents.Count(); i++)
            {
                fullContent.AddRange(documents[i].Content);
            }

            File.WriteAllBytes($"{Constants.FolderBasePath}{Constants.LocalSavesFolderName}\\{key}", fullContent.ToArray());
            _logger.Information($"File {key} was saved to local folder");

            MessageParts.RemoveAll(d => d.FileName == key);
        }
    }
}
