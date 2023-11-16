using Common;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataCaptureService
{
    public class DataCaptureHostedService : IHostedService
    {
        IFileFolderMonitoringService _fileFolderMonitoringService;

        public DataCaptureHostedService(IFileFolderMonitoringService dataCaptureService)
        {
            _fileFolderMonitoringService = dataCaptureService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => _fileFolderMonitoringService.MonitorFileFolder());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
