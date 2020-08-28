using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using exchange.core.implementations;
using exchange.core.interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace exchange.service
{
    public class Worker : BackgroundService
    {
        private readonly IExchangePluginService _exchangePluginService;
        private readonly IExchangeService _exchangeService;
        private readonly IExchangeSettings _exchangeSettings;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IExchangeSettings exchangeSettings, IExchangeService exchangeService, IExchangePluginService exchangePluginService)
        {
            _logger = logger;
            _exchangeSettings = exchangeSettings;
            _exchangeService = exchangeService;
            _exchangePluginService = exchangePluginService;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Worker started at: {DateTime.Now}");
            if (_exchangePluginService.PluginExchanges != null && _exchangePluginService.PluginExchanges.Any())
            {
                for (int i = _exchangePluginService.PluginExchanges.Count-1; i >= 0; i--)
                {
                    AbstractExchangePlugin abstractExchangePlugin = _exchangePluginService.PluginExchanges[i];
                    abstractExchangePlugin.NotifyAccountInfo += _exchangeService.DelegateNotifyAccountInfo;
                    abstractExchangePlugin.NotifyCurrentPrices += _exchangeService.DelegateNotifyCurrentPrices;
                    await abstractExchangePlugin.InitAsync(_exchangeSettings.TestMode);
                    abstractExchangePlugin.InitIndicatorsAsync();
                    _logger.LogInformation($"Plugin {abstractExchangePlugin.ApplicationName} loaded.");
                }
            }
            await base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Worker stopped at: {DateTime.Now}");
            if (_exchangePluginService.PluginExchanges == null || !_exchangePluginService.PluginExchanges.Any())
                return base.StopAsync(cancellationToken);
            for (int i = _exchangePluginService.PluginExchanges.Count - 1; i >= 0; i--)
            {
                AbstractExchangePlugin abstractExchangePlugin = _exchangePluginService.PluginExchanges[i];
                abstractExchangePlugin.CloseFeed().GetAwaiter();
            }
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _logger.LogInformation($"Worker disposed at: {DateTime.Now}");
            if (_exchangePluginService.PluginExchanges != null && _exchangePluginService.PluginExchanges.Any())
            {
                for (int i = _exchangePluginService.PluginExchanges.Count - 1; i >= 0; i--)
                {
                    AbstractExchangePlugin abstractExchangePlugin = _exchangePluginService.PluginExchanges[i];
                    abstractExchangePlugin.Dispose();
                }
            }
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}