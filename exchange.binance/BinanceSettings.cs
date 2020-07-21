﻿using exchange.core.models;
using exchange.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace exchange.binance
{
    [Serializable]
    public class BinanceSettings
    {
        [JsonPropertyName("server_time")]
        public ServerTime ServerTime { get; set; }
        [JsonPropertyName("current_prices")]
        public Dictionary<string, decimal> CurrentPrices { get; set; }
        public List<Ticker> Tickers { get; set; }
        public List<Account> Accounts { get; set; }
        [JsonPropertyName("accounts")]
        public BinanceAccount BinanceAccount { get; set; }
        [JsonPropertyName("exchange_info")]
        public ExchangeInfo ExchangeInfo { get; set; }
    }
}
