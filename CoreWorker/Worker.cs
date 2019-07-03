using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreWorker
{
    public class Worker : BackgroundService
    {
        #region Private Fields

        private readonly ILogger<Worker> _logger;

        #endregion

        #region Initialization

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Protected Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        #endregion
    }
}