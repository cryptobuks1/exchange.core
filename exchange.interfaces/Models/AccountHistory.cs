﻿using System.Text.Json.Serialization;

namespace exchange.core.Models
{
    public class AccountHistory : Error
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        [JsonPropertyName("balance")]
        public string Balance { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("details")]
        public Detail Detail { get; set; }
    }
}
