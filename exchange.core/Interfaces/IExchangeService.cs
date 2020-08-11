﻿using System;
using exchange.core.models;
using System.Collections.Generic;
using System.Threading.Tasks;
using exchange.core.Enums;
using exchange.core.Models;
using exchange.core.Interfaces;
using System.Net.WebSockets;
using exchange.core.implementations;

namespace exchange.core.interfaces
{
    /// <summary>
    /// All exchange services have to implement the IExchangeService interface
    /// This interface will also be used to forward Hub Requests
    /// </summary>
    public interface IExchangeService
    {
        #region Actions
        Action<string, Dictionary<string, string>> TechnicalIndicatorInformationBroadcast { get; set; }
        Action<string, Dictionary<string, decimal>> AccountInfoBroadcast { get; set; }
        Action<string, Feed> FeedBroadcast { get; set; }
        Action<string, MessageType, string> ProcessLogBroadcast { get; set; }
        #endregion

        void RequestCurrentPrices();
        void RequestAccountInfo();

        #region Properties
        string INIFilePath { get; set; }
        bool TestMode { get; set; }
        Feed CurrentFeed { get; set; }
        Authentication Authentication { get; set; }
        ClientWebSocket ClientWebSocket { get; set; }
        ConnectionAdapter ConnectionAdapter { get; set; }
        Dictionary<string, decimal> CurrentPrices { get; set; }
        Dictionary<string, decimal> AccountInfo { get; set; }
        List<Product> Products { get; set; }
        #endregion

        #region Methods
        Task<bool> InitAsync(bool testMode);
        bool InitIndicatorsAsync();
        Task<bool> CloseFeed();
        bool ChangeFeed(string message);
        Task<List<HistoricRate>> UpdateProductHistoricCandlesAsync(HistoricCandlesSearch historicCandlesSearch);
        #endregion

        public void Dispose();
    }
}
