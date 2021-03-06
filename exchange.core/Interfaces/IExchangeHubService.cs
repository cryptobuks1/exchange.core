﻿using System.Collections.Generic;
using System.Threading.Tasks;
using exchange.core.models;

namespace exchange.core.interfaces
{
    public interface IExchangeHubService
    {
        Task RequestedAccountInfo();
        Task RequestedCurrentPrices();
        Task RequestedProducts();
        Task RequestedApplications();
        Task RequestedSubscription(string applicationName, List<string> symbols);
        Task NotifyApplications(List<string> applicationNames);
        Task NotifyCurrentPrices(string applicationName, Dictionary<string, decimal> currentPrices);
        Task NotifyAccountInfo(string applicationName, Dictionary<string, decimal> accountInformation);
        Task NotifyProductChange(string applicationName, List<Product> products);
    }
}