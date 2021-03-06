﻿using System.Collections.Generic;
using System.Threading.Tasks;
using exchange.core.interfaces;
using Microsoft.AspNetCore.SignalR;

namespace exchange.core.implementations
{
    public 
        class ExchangeService : IExchangeService
    {
        private readonly IHubContext<ExchangeHubService, IExchangeHubService> _exchangeHubService;

        public ExchangeService(IHubContext<ExchangeHubService, IExchangeHubService> exchangeHubService)
        {
            _exchangeHubService ??= exchangeHubService;
        }

        public async Task DelegateNotifyCurrentPrices(string applicationName, Dictionary<string, decimal> currentPrices)
        {
            if (_exchangeHubService.Clients == null)
                return;
            await _exchangeHubService.Clients.All.NotifyCurrentPrices(applicationName, currentPrices);
        }

        public async Task DelegateNotifyAccountInfo(string applicationName,
            Dictionary<string, decimal> accountInformation)
        {
            if (_exchangeHubService.Clients == null)
                return;
            await _exchangeHubService.Clients.All.NotifyAccountInfo(applicationName, accountInformation);
        }

        public Task DelegateNotifyTradeInfo(string applicationName, Dictionary<string, decimal> accountInformation)
        {
            throw new System.NotImplementedException();
        }
    }
}