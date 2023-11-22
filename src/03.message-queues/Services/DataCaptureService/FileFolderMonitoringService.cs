using common.messageQueuesTask;
using Common;
using Common.Models;
using Kafka.Producer;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataCapturingService
{
    public class FileFolderMonitoringService : IFileFolderMonitoringService
    {
        IKafkaProducer _producer;
        ILogger _logger;

        public FileFolderMonitoringService(IKafkaProducer producer, ILogger logger)
        {
            _producer = producer;
            _logger = logger;
        }

        public void MonitorFileFolder()
        {
            var watcher = new FileSystemWatcher();
            watcher.Path = $"{Constants.FolderBasePath}{Constants.MonitoredFolderName}";
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.pdf";
            watcher.Created += new FileSystemEventHandler(OnCreatedAsync);
            watcher.Renamed += new RenamedEventHandler(OnCreatedAsync);
        }

        private void OnCreatedAsync(object source, FileSystemEventArgs eventArgs)
        {
            if (eventArgs.ChangeType == WatcherChangeTypes.Created)
            {
                while (true)
                {
                    try
                    {
                        var newFile = File.ReadAllBytes(eventArgs.FullPath);
                        var chunks = new List<byte[]>() { newFile };

                        if (newFile.Length > Constants.MaxFileSize)
                        {
                            chunks = newFile.Chunk(Constants.MaxFileSize / 2).ToList();
                        }

                        for (int chunk = 0; chunk < chunks.Count; chunk++)
                        {
                            var message = new Message(Guid.NewGuid().ToString(),
                                new MessageValue()
                                {
                                    FileName = eventArgs.Name,
                                    Content = chunks[chunk],
                                    ChunkSize = chunks.Count,
                                    Position = chunk
                                });

                            _producer.ProduceMessageAsync(message);
                        }

                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, ex.Message);
                    }
                }
            };
        }
    }
}
